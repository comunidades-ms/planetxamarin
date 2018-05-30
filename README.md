# Bienvenido [![Build status](https://ci.appveyor.com/api/projects/status/lpkmo9pftmku26ck?svg=true)](https://ci.appveyor.com/project/wilsonvargas/NN)

Hola! Bienvenido al portal Comunidades Microsoft!

Si escribes sobre tecnologías Microsoft, tú perteneces aquí. Estaremos muy contentos de que seas parte de la comunidad y que puedas agregar tu blog como parte de nuestro feed siempre y cuando el contenido que está compartiendo no infrinja el [código de conducta](CODE_OF_CONDUCT.md)

# Agrega tu blog tú mismo

### Pautas para ser parte de este portal
- Tener un blog y un RSS con urls válidos, ambos usando HTTPS con un certificado válido.
- NO tengo contenido malicioso u ofensivo en mi blog (incluidas fotos, maldiciones, etc.).
- Mi blog está activo con al menos 3 publicaciones relacionadas con tecnologías Microsoft en los últimos 6 meses.
- Si mi blog tiene contenido variado (artículos personales, artículos no relacionados) tendré agregar el filtro en mi contribución.
- Si borras tu blog serás eliminado del portal de Comunidades Microsoft.
- Tu blog puede ser eliminado en cualquier momento si alguna de estas pautas se rompe.

### Cómo agregarme

Para ser parte de este portal tú tienes que hacer un fork de este proyecto, agregarte a la [carpeta Authors](/src/Firehose.Web/Authors) como una clase, implementar la interfaz `IAmACommunityMember`. Si estás haciendo esto a través del editor de GitHub, no te olvides de _agregar la clase al archivo .csproj_.

El resultado debería verse algo así:

``` csharp
public class WilsonVargas : IAmACommunityMember
{
    public string FirstName => "Wilson";
    public string LastName => "Vargas";
    public string ShortBioOrTagLine => "al parecer es un zombie";
    public string StateOrRegion => "Trujillo, Peru";
    public string EmailAddress => "wilsonvargas@developermodeon.com";
    public string TwitterHandle => "wilsonvargas_m";
    public string GravatarHash => "3544142bb4e";
    public string GitHubHandle => "wilsonvargas";
    public GeoPosition Position => new GeoPosition(47.643417, -122.126083);
    public Uri WebSite => new Uri("https://blog.wilsonvargas.com");
    public IEnumerable<Uri> FeedUris { get { yield return new Uri("https://blog.wilsonvargas.com/rss/"); } }
}
```

A few things: 
- Name the class after your first and lastname with PascalCase
- The `FirstName` and `LastName` property should resemble that same name
- `ShortBioOrTagLine` property can be whatever you like. If you can't think of anything choose: 'software engineer' or 'software engineer at Microsoft'. Please keep it short, like a 140 character tweet.
- `StateOrRegion` will be your geographical location, i.e.: Holland, New York, etc.
- `EmailAddress`, `TwitterHandle` and `GitHubHandle` should be pretty clear, `TwitterHandle` without the leading @
- `Position` is your latitude and longitude, this allows you to be placed on the map on the Authors page
- The `Website` property can be your global website or whatever you want people to look at
- With `FeedUris` you can supply one or more URIs which resemble your blogs. Your blogs should be provided in RSS (Atom) format and of course be about Xamarin.
- And finally `FeedLanguageCode` specifies in what lanuage the majority of your content will be. This is used to be able to apply filters to the feed. This language code should be in [ISO 639-1 format](https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes)
- If you do not want your e-mailaddress publicly available but you _do_ want to show your Gravatar go to https://en.gravatar.com/site/check/ and get your hash! If you don't fill the hash, you will be viewed as a silhouette.

If you also do some blogging about other stuff, no worries! You're fine! Just have a look at the next section on how to filter out your Xamarin specific posts.

# Just Xamarin please

Per default PlanetXamarin implements a default filter looking for Xamarin in the title and categories (tags) you have on your blog posts. This behavior can be modified by implementing `IFilterMyBlogPosts`, where you can implement your own filtering logic.
It could be that you want to disable all filtering because your blog is solely about Xamarin. Maybe, you run a Xamarin newsletter or podcast.

``` csharp
public class BruceWayne : IAmACommunityMember, IFilterMyBlogPosts
{
    // ... Author properties from the above class, removed for brevity

    public bool Filter(SyndicationItem item)
    {
        // Here you filter out the given item by the criteria you want, i.e.
        // this filters out posts that do not have Xamarin in the title
        return item.Title.Text.ToLowerInvariant().Contains("xamarin");
        
        // This filters out only the posts that have the "xamarin" category
        // Not all blog posts have categories, please guard against this
        return item.Categories?.Any(c => c.Name.ToLowerInvariant().Equals("xamarin")) ?? false;
        
        // Of course you can make the checks as complicated as you want and combine some stuff
        return item.Title.Text.ToLowerInvariant().Contains("xamarin") && (item.Categories?.Any(c => c.Name.ToLowerInvariant().Equals("xamarin")) ?? false);
    }
}
```

# A small step for an author...

A big step for mankind! Last thing that remains is submit a Pull Request to us and whenever it gets merged: hooray! You're an author now!

Don't forget to incorporate the Featured on Planet Xamarin badge on your blog and link back to us!


![Featured on Planet Xamarin Badge](https://www.planetxamarin.com/Content/img/planetxamarin-featured-badge.png)

Enjoy all of our great content! 

Of course you are more than welcome to submit other features and bugfixes as well.

# Acknowledgements
* Thanks to Readify for open sourcing their employee blog aggregation platform which we forked to create PlanetXamarin. Looking for your next challenge? [Readify is hiring](https://join.readify.net/?source=StaffReferral&campaign=geoffrey.huntley) and offers relocation services for developers from abroad.
* Thanks to [our awesome contributors](https://github.com/planetxamarin/planetxamarin/graphs/contributors) and our [community of authors](https://github.com/planetxamarin/planetxamarin/tree/master/src/Firehose.Web/Authors) who make this all possible.
