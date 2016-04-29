using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


[ServiceContract]
public interface IService
{
    [OperationContract]
    List<string> GetShows();

    [OperationContract]
    List<string> GetVenues();

    [OperationContract]
    List<string> GetArtists();

    [OperationContract]

    List<ShowInfo> GetShowByVenue(string VenueName);

    [OperationContract]
    List<ShowInfo> GetShowByArtist(string ArtistName);

}

[DataContract]
public class ShowInfo
{
    [DataMember]
    public string ShowName { set; get; }

    [DataMember]
    public string ShowDate { set; get; }

    [DataMember]
    public string ShowTime { set; get; }

    [DataMember]
    public string VenueName { set; get; }

}