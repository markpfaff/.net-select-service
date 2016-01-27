using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SelectServiceService" in code, svc and config file together.
public class SelectServiceService : ISelectServiceService
{
    ShowTrackerEntities st = new ShowTrackerEntities();
 
    public List<string> GetArtists()
    {
        var arts = from a in st.Artists
                    orderby a.ArtistName
                    select new { a.ArtistName };
        List<string> artists = new List<string>();
        foreach (var a in arts)
        {
            artists.Add(a.ArtistName.ToString());
        }

        return artists;
    }

    public List<ShowLite> GetShowByArtist(string artistname)
    {
        var shw = from s in st.Shows
                  from sd in s.ShowDetails

                  where sd.Artist.ArtistName.Equals(artistname)
                  select new { s.Venue.VenueName, s.ShowName, s.ShowDateEntered };
        List<ShowLite> showba = new List<ShowLite>();
        foreach (var s in shw)
        {
            ShowLite slite = new ShowLite();
            slite.VenueName = s.VenueName;
            slite.ShowName = s.ShowName;
            slite.ShowDate = s.ShowDateEntered.ToString();

            showba.Add(slite);
        }

        return showba;
    }

    public List<ShowLite> GetShowByVenue(string venuename)
    {
        var shw = from s in st.Shows
                  from sd in s.ShowDetails

                  where sd.Artist.ArtistName.Equals(venuename)
                  select new { s.Venue.VenueName, s.ShowName, s.ShowDateEntered };
        List<ShowLite> showbv = new List<ShowLite>();
        foreach (var s in shw)
        {
            ShowLite slite = new ShowLite();
            slite.VenueName = s.VenueName;
            slite.ShowName = s.ShowName;
            slite.ShowDate = s.ShowDateEntered.ToString();

            showbv.Add(slite);
        }

        return showbv;
    }

    public List<string> GetShows()
    {
        var shw = from s in st.Shows
                    orderby s.ShowName
                    select new { s.ShowName };
        List<string> shows = new List<string>();
        foreach (var s in shw)
        {
            shows.Add(s.ShowName.ToString());
        }

        return shows;
    }

    public List<string> GetVenues()
    {
        var vens = from v in st.Venues
                    orderby v.VenueName
                    select new { v.VenueName };
        List<string> authors = new List<string>();
        foreach (var v in vens)
        {
            authors.Add(v.VenueName.ToString());
        }

        return authors;
    }
}
