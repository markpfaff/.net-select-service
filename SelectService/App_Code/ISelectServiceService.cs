using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISelectServiceService" in both code and config file together.
[ServiceContract]
public interface ISelectServiceService
{
    [OperationContract]
    List<string> GetArtists();
    [OperationContract]
    List<string> GetShows();
    [OperationContract]
    List<string> GetVenues();
    [OperationContract]
    List<ShowLite> GetShowByVenue(string venuename);
    [OperationContract]
    List<ShowLite> GetShowByArtist(string artistname);
}
[DataContract]
public class ShowLite
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
