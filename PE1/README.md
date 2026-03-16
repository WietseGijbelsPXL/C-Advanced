[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/mWhspPPP)
##  Algemeen
Je werkt voor een klein kookplatform dat een desktopapplicatie wil om keukenrecepten te beheren. De applicatie moet recepten kunnen bekijken, toevoegen, bewerken, verwijderen en opslaan.

De applicatie wordt ontwikkeld als WPF desktopapplicatie volgens Clean Architecture gebaseerd op Domain Driven Design.

De gegevens moeten kunnen worden opgeslagen en geladen uit CSV en JSON bestanden.

## Architecture
We moeten de architectuur volgens het DDD principe toepassen. Voorzie de bestaande `RecipeManager` solution van onderstaande projecten en leg de nodige projectreferenties.

* `RecipeManager.Domain` (Class Library, .NET 8)
* `RecipeManager.Infrastructure` (Class Library, .NET 8)
* `RecipeManager.Application` (Class Library, .NET 8)
* `RecipeManager.Presentation` (WPF App, .NET 8)

## RecipeManager.Domain
Maak een `Models` folder en voeg hierin onderstaande klasse toe.

### Recipe
| NAME  | DATATYPE  |
|:---|:---|
| Id | `Guid` |
| Name | `string` |
| PreparationTime | `int` |
| Difficulty | `string` |
| Ingredients | `List<string>` |

De `PreparationTime` moet tussen 1 en 180 minuten liggen. Genereer een ArgumentException met de melding "Voorbereidingstijd moet tussen 1 en 180 minuten liggen." wanneer deze buiten bereik valt.

Implementeer onderstaande ToString() methode:

```
return $"{Name} ({PreparationTime} min, {Difficulty})";
```

## RecipeManager.Infrastructure
Maak een repository `RecipeJsonRepository` waarin je in een lokale variabele `_recipes` een lijst van recepten bijhoudt. Voorzie daarnaast volgende methodes:

* `void Import(string jsonFile)`
  * Hier ga je eerst controleren of het bestand `jsonFile` bestaat. Indien niet throw je een FileNotFoundException.
  * Importeer alle gegevens in de JSON file en vul hiermee de `_recipes` lijst.
  * Een voorbeeldbestand `recepten.json` zit in de repository op Github.
* `List<Recipe> GetAll()`
  * Geef de lijst van recepten terug
* `void Add(Recipe recipe)`
  * Genereer een nieuwe Id (TIP: `Guid.NewGuid();`)
  * Voeg het recept toe aan de lijst van recepten
* `void Update(Recipe recipe)`
  * Update het recept in de lijst van recepten
  * TIP: `_recipes.FindIndex(r => r.Id == recipe.Id)`
* `void Delete(Guid id)`
  * Verwijder het recept uit de lijst van recepten
* `void Save(string jsonFile)`
  * Serializeer de lijst van recepten in een JSON string en schrijf deze vervolgens weg naar het bestand uit de parameter `jsonFile`.

## RecipeManager.Application
Maak voor een service `RecipeService` die de repository gebruikt voor het beheer van recepten.

* Voorzie een property `Saved` die bijhoudt of de recepten zijn opgeslagen of niet. Deze property mag publiek gelezen worden, maar enkel lokaal (private) gezet. Zorg ervoor dat deze property na elke actie de juiste waarde krijgt toegewezen.
* In de constructor wordt een `RecipeJsonRepository` object meegegeven en lokaal bijgehouden.
* `void LoadRecipes(string path)`
  * Roept de `Import` op van de repository
* `List<Recipe> GetRecipes()`
  * Gebruikt de `GetAll` van de repository
* `void AddRecipe(Recipe recipe)`
  * Een recept met moeilijkheidsgraad "Moeilijk" moet minstens 3 ingrediënten hebben. Indien dit niet zo is maak je een InvalidDataException met een gepaste melding.
  * Gebruikt de `Add` van de repository
* `void UpdateRecipe(Recipe recipe)`
  * Gebruikt de `Update` van de repository
* `void DeleteRecipe(Recipe recipe)`
  * Gebruikt de `Delete` van de repository
* `void SaveRecipes(string path)`
  * Roept de `Save` op van de repository

## RecipeManager.Presentation
De presentie laag bevat in totaal 3 schermen.

### MainWindow
Dit is het startscherm van de applicatie en wordt leeg getoond bij het laden.

* De knop *Laad JSON* vraagt via een _OpenFileDialog_ venster naar de locatie van de te importeren JSON file. Het venster moet een filter hebben zoals hieronder getoond. Gebruik hiervoor de `LoadRecipes` van de service (applicatie laag). Roep daarna de methode `FillListBox` op om de recepten te tonen.

![](/images/FilterJson.png)

* Maak een methode `FillListBox` om de recepten te tonen in de ListBox. Wanneer er geen items zijn worden de knoppen `SaveJsonButton` en `ExportCsvButton` disabled.
* Bij het dubbelklikken van een item uit de ListBox ga je het detailscherm tonen. Je toont dit *niet* in modaal en je zorgt ervoor dat deze window maar 1 keer wordt getoond. De gebruiker kan nog steeds in het overzichtscherm op een ander item dubbelklikken terwijl het detailscherm open staat. Uiteraard wordt dan het nieuw aangeklikte item getoond in het detailscherm. Meer info over dit scherm vind je verder (onder MainWindow).
* De knop *Sla JSON op* gaat de recepten exporteren naar een JSON bestand. Vraag de gebruiker via een _SaveFileDialog_ naar de locatie en de naam van het bestand. Dit geef je mee aan de `SaveRecipes` methode van de service. Gebruik dezelfde filter als bij de *Laad JSON* knop.

![](/images/FilterJson.png)

* De knop *Toevoegen* toont het `RecipeEditWindow` in modal mode met een `null` als parameter. Indien dit scherm bevestigd wordt, voeg je het nieuwe recept toe met de `AddRecipe` methode van de service en roep je daarna de `FillListBox` methode op om het scherm te refreshen.
* De knop *Wijzigen* toont ook het `RecipeEditWindow` in modal mode, maar je gebruikt het geselecteerde object uit de `recipesListBox` om als parameter mee te geven (i.p.v. null). Daarnaast ga je het recept updaten door de `UpdateRecipe` methode van de service op te roepen. Tenslotte refresh je de ListBox door `FillListBox` op te roepen. 
* De knop *Verwijderen* vraagt eerst een bevestiging alvorens het geselecteerde item verwijderd wordt. Zorg voor exact dezelfde vraagstelling zoals hieronder getoond. Bij bevestiging ga je met de `DeleteRecipe` methode van de service het recept verwijderen. Ook hier roep je daarna de `FillListBox` methode op om het scherm te refreshen.

![](/images/Delete.png)

* De knop *Export CSV* gaat naam, voorbereidingstijd en moeilijkheid wegschrijven naar een CSV bestand. Gebruik puntkomma *;* als separator. Net zoals de knop *Sla JSON op* ga je via een _SaveFileDialog_ naar de locatie en naam van de CSV file vragen. Uiteraard ga je geen JSON files, maar CSV files filteren.

![](/images/FilterCSV.png)

* Bij het sluiten van het scherm ga je controleren of er niet-opgeslagen wijzigingen zijn. Hiervoor gebruik je de `Saved` property van de service. Als deze false teruggeeft ga je eerste bevestiging van afsluiten vragen, zoals hieronder getoond. Wanneer hier negatief op geantwoord wordt, ga je het scherm *niet* afsluiten.

![](/images/Close.png)

### RecipeDetailWindow
Dit scherm wordt gebruikt om de details van een recept te tonen na het dubbelklikken in de ListBox in MainWindow.
Omdat dit niet modaal getoond wordt ga je gebruik maken van een write-only property `Recipe`. Hierin ga je de details van het ontvangen recept tonen in de overeenkomstige TextBlocken en ListBox.

Dit scherm zit al volledig uitgewerkt in de opgave. Je moet er enkel voor zorgen dat dit geen compile error geeft op "Recipe".

![](/images/ReceptDetail.png)

### RecipeEditWindow
Dit scherm wordt gebruikt om een nieuw recept toe te voegen of om een bestaand recept te wijzigen.
* Gebruik onderstaande code in de constructor om dit onderscheid te maken.
* Maak een property `Recipe` die publiek toegankelijk is.
* Maak een methode `RefreshListBox` die de lijst van ingrediënten toont in de ListBox.

```
if (recipe != null)
{
    Recipe = recipe;
    nameTextBox.Text = recipe.Name;
    preparationTimeTextBox.Text = recipe.PreparationTime.ToString();
    difficultyComboBox.Text = recipe.Difficulty;
    RefreshListBox();
    Title = "Wijzig recept";
}
else
{
    Recipe = new Recipe();
    Title = "Nieuw recept";
}
```

* Met de knop *Voeg ingrediënt toe* ga je een nieuw ingrediënt toevoegen aan het recept. Lees hiervoor de Textbox uit en voeg deze toe aan de lijst van ingrediënten.
* De knop *Verwijder* gaat het geselecteerde ingrediënt verwijderen uit de lijst.
  * TIP: Recipe.Ingredients is een List. Gebruik de gekende methode om een item hieruit te verwijderen.
* Bij het opslaan ga je eerst controleren of alle velden zijn ingevuld. Zo niet toon je deze melding en sluit het scherm niet af.
  * TIP: overschrijf de eigenschappen van de publieke Recipe property met de inhoud van de input controls

![](/images/SaveError.png)

Succes!
