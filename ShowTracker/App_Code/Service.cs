using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


public class Service : IService
{
    ShowTrackerEntities db = new ShowTrackerEntities();
    public List<string> GetArtists()
    {
        var artist = from a in db.Artists orderby a.ArtistName select new { a.ArtistName };

        List<string> aName = new List<string>();
        foreach (var a in artist)
        {
            aName.Add(a.ArtistName.ToString());
        }
        return aName;
    }

    public List<ShowInfo> GetShowByArtist(string ArtistShowName)
    {
        List<ShowInfo> artshow = new List<ShowInfo>();
        var show = from s in db.Shows
                   from a in s.ShowDetails
                   where a.Artist.ArtistName.Equals(ArtistShowName)
                   select new { s.ShowName, s.ShowDate, s.ShowTime, s.Venue.VenueName };      
        foreach (var sa in show)
        {
            ShowInfo info = new ShowInfo();
            info.ShowName = sa.ShowName;
            info.ShowDate = sa.ShowDate.ToString();
            info.ShowTime = sa.ShowTime.ToString();
            info.VenueName = sa.VenueName;

            artshow.Add(info);

        }
        return artshow;
    }


    public List<ShowInfo> GetShowByVenue(string VenueShowName)
    {
        List<ShowInfo> venShow = new List<ShowInfo>();
        var vshow = from sh in db.Shows
                    from v in sh.ShowDetails
                    where v.Show.Venue.VenueName.Equals(VenueShowName)
                   select new { sh.ShowName, sh.ShowDate, sh.ShowTime, sh.Venue.VenueName };
        foreach (var sa in vshow)
        {
            ShowInfo info = new ShowInfo();
            info.ShowName = sa.ShowName;
            info.ShowDate = sa.ShowDate.ToString();
            info.ShowTime = sa.ShowTime.ToString();
            info.VenueName = sa.VenueName;

            venShow.Add(info);

        }
        return venShow;
    }

    public List<string> GetShows()
    {
        var shows = from s in db.Shows orderby s.ShowName select new { s.ShowName };

        List<string> sName = new List<string>();
        foreach (var s in shows)
        {
            sName.Add(s.ShowName.ToString());
        }
        return sName;
    }

    public List<string> GetVenues()
    {
        var venues = from v in db.Venues orderby v.VenueName select new { v.VenueName };

        List<string> vName = new List<string>();
        foreach (var v in venues)
        {
            vName.Add(v.VenueName.ToString());
        }
        return vName;
    }
}
