using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using Firehose.Web.Infrastructure;

namespace Firehose.Web.Authors
{
    public class WilsonVargas : IAmACommunityMember
    {
        public string FirstName => "Wilson";
        public string LastName => "Vargas";
        public string StateOrRegion => "Trujillo, Peru";
        public string EmailAddress => "";
        public string ShortBioOrTagLine => "es un chico con mucha experiencia en el arte del desarrollo de software y con una gran pasión por el desarrollo de aplicaciones móviles usando Xamarin.";
        public Uri WebSite => new Uri("https://blog.wilsonvargas.com");

        public IEnumerable<Uri> FeedUris
        {
            get { yield return new Uri("https://blog.wilsonvargas.com/rss/"); }
        }

        public string TwitterHandle => "Wilson_VargasM";
        public string GravatarHash => "3544142bb4ef8f597b1c14b887b0b905";
        public string GitHubHandle => "wilsonvargas";
        public GeoPosition Position => new GeoPosition(-8.120174, -79.035157);
    }
}