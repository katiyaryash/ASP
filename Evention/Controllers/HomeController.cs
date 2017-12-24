using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Evention.Models;
using System.Data.OleDb;
using System.Data;
using System.Xml;
using System.Reflection;
namespace Evention.Controllers
{
    public class HomeController : Controller
    {
        public static EventModel eventModel = new EventModel();
        CustomEntities db = new CustomEntities();

        ViewEvents objViewEvents = new ViewEvents();
        ViewEvents obj = new ViewEvents();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Events()
        {
            // List<EventModel> lstEventCategory = new List<EventModel>();
            EventModel objEventModel = new EventModel();
            ViewEvents objViewEvents = new ViewEvents();
            try
            {
                var con = ConfigurationManager.ConnectionStrings["CustomEntities"].ToString();
                using (SqlConnection myConnection = new SqlConnection(con))
                {
                    myConnection.Open();
                    string events = "Select * from EventList";
                    SqlCommand oCmd = new SqlCommand(events, myConnection);
                    oCmd.Parameters.AddWithValue("@EName", eventModel.EName ?? (object)DBNull.Value);
                    oCmd.Parameters.AddWithValue("@BgImage", eventModel.BgImage ?? (object)DBNull.Value);

                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            eventModel.EName = oReader["EName"].ToString();
                            eventModel.BgImage = oReader["BgImage"].ToString();
                            //lstEventCategory.Add(eventModel);
                            objViewEvents.lstEventCategory.Add(new EventModel { Category = eventModel.EName });


                        }

                        myConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View(objViewEvents);
        }
        public ActionResult AllEvents()
        {

            try
            {

                var con = ConfigurationManager.ConnectionStrings["CustomEntities"].ToString();
                using (SqlConnection myConnection = new SqlConnection(con))
                {
                    myConnection.Open();
                    //string events = "Select Feature,Type,Category,Date,Start,End,Place,Address,Lon,Lat,About,Website,Image from EventDetail";
                    string events = "Select Feature,Type,Category,Date,Place,Address,Lon,Lat,About,Website,Image from EventDetail LEFT JOIN EventList ON EventDetail.Type=EventList.EName";
                    SqlCommand oCmd = new SqlCommand(events, myConnection);
                    oCmd.Parameters.AddWithValue("@Feature", eventModel.Feature ?? (object)DBNull.Value);
                    oCmd.Parameters.AddWithValue("@Type", eventModel.Type ?? (object)DBNull.Value);
                    oCmd.Parameters.AddWithValue("@Category", eventModel.ECategory ?? (object)DBNull.Value);
                    oCmd.Parameters.AddWithValue("@Date", eventModel.Date ?? (object)DBNull.Value);
                    //oCmd.Parameters.AddWithValue("@Start", eventModel.Start ?? (object)DBNull.Value);
                    //oCmd.Parameters.AddWithValue("@End", eventModel.End ?? (object)DBNull.Value);
                    oCmd.Parameters.AddWithValue("@Place", eventModel.Place ?? (object)DBNull.Value);
                    oCmd.Parameters.AddWithValue("@Address", eventModel.Address ?? (object)DBNull.Value);
                    //oCmd.Parameters.AddWithValue("@Lon", eventModel.Lon);
                    //oCmd.Parameters.AddWithValue("@Lat", eventModel.Lat);
                    oCmd.Parameters.AddWithValue("@About", eventModel.About ?? (object)DBNull.Value);
                    oCmd.Parameters.AddWithValue("@Website", eventModel.Website ?? (object)DBNull.Value);
                    oCmd.Parameters.AddWithValue("@Image", eventModel.Image ?? (object)DBNull.Value);

                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {

                        while (oReader.Read())
                        {

                            eventModel.Feature = oReader["Feature"].ToString();
                            eventModel.Type = oReader["Type"].ToString();
                            eventModel.ECategory = oReader["Category"].ToString();
                            eventModel.Date = oReader["Date"].ToString();
                            //eventModel.Start = oReader["Start"].ToString();
                            //eventModel.End = oReader["End"].ToString();
                            eventModel.Place = oReader["Place"].ToString();
                            eventModel.Address = oReader["Address"].ToString();
                            //eventModel.Lon = Convert.ToDecimal(oReader["Lon"]);
                            //eventModel.Lat = Convert.ToDecimal(oReader["Lat"]);
                            eventModel.About = oReader["About"].ToString();
                            eventModel.Website = oReader["Website"].ToString();
                            eventModel.Image = oReader["Image"].ToString();
                            objViewEvents.lstEventDetails.Add(new EventModel
                            {
                                Feature = eventModel.Feature,
                                Type = eventModel.Type,
                                ECategory = eventModel.ECategory,
                                Date = eventModel.Date,
                                Place = eventModel.Place,
                                Address = eventModel.Address,
                                About = eventModel.About,

                            });
                        }

                        //myConnection.Close();
                    }

                }
                using (SqlConnection myConnection = new SqlConnection(con))
                {
                    myConnection.Open();
                    string events1 = "Select * from EventList";
                    SqlCommand oCmd1 = new SqlCommand(events1, myConnection);
                    oCmd1.Parameters.AddWithValue("@EName", eventModel.EName ?? (object)DBNull.Value);
                    oCmd1.Parameters.AddWithValue("@BgImage", eventModel.BgImage ?? (object)DBNull.Value);

                    using (SqlDataReader oReader1 = oCmd1.ExecuteReader())
                    {
                        while (oReader1.Read())
                        {
                            eventModel.EName = oReader1["EName"].ToString();
                            eventModel.BgImage = oReader1["BgImage"].ToString();
                            //lstEventCategory.Add(eventModel);
                            objViewEvents.lstEventCategory.Add(new EventModel { Category = eventModel.EName });


                        }

                        myConnection.Close();
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return View(objViewEvents);
        }
        public ActionResult ContentPage()
        {
            try
            {
                var con = ConfigurationManager.ConnectionStrings["CustomEntities"].ToString();
                using (SqlConnection myConnection = new SqlConnection(con))
                {
                    myConnection.Open();
                    string events = "Select Feature,Type,Category,Date,Place,Address,Lon,Lat,About,Website,Image,Cost from EventDetail LEFT JOIN EventList ON EventDetail.Type=EventList.EName";

                    SqlCommand oCmd = new SqlCommand(events, myConnection);
                    oCmd.Parameters.AddWithValue("@Feature", eventModel.Feature ?? (object)DBNull.Value);
                    oCmd.Parameters.AddWithValue("@Type", eventModel.Type ?? (object)DBNull.Value);
                    oCmd.Parameters.AddWithValue("@Category", eventModel.ECategory ?? (object)DBNull.Value);
                    oCmd.Parameters.AddWithValue("@Date", eventModel.Date ?? (object)DBNull.Value);
                    //oCmd.Parameters.AddWithValue("@Start", eventModel.Start ?? (object)DBNull.Value);
                    //oCmd.Parameters.AddWithValue("@End", eventModel.End ?? (object)DBNull.Value);
                    oCmd.Parameters.AddWithValue("@Place", eventModel.Place ?? (object)DBNull.Value);
                    oCmd.Parameters.AddWithValue("@Address", eventModel.Address ?? (object)DBNull.Value);
                    //oCmd.Parameters.AddWithValue("@Lon", eventModel.Lon);
                    //oCmd.Parameters.AddWithValue("@Lat", eventModel.Lat);
                    oCmd.Parameters.AddWithValue("@About", eventModel.About ?? (object)DBNull.Value);
                    oCmd.Parameters.AddWithValue("@Website", eventModel.Website ?? (object)DBNull.Value);
                    oCmd.Parameters.AddWithValue("@Image", eventModel.Image ?? (object)DBNull.Value);
                    oCmd.Parameters.AddWithValue("@Cost", eventModel.Cost ?? (object)DBNull.Value);


                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {

                        while (oReader.Read())
                        {

                            eventModel.Feature = oReader["Feature"].ToString();
                            eventModel.Type = oReader["Type"].ToString();
                            eventModel.ECategory = oReader["Category"].ToString();
                            eventModel.Date = oReader["Date"].ToString();
                            //eventModel.Start = oReader["Start"].ToString();
                            //eventModel.End = oReader["End"].ToString();
                            eventModel.Place = oReader["Place"].ToString();
                            eventModel.Address = oReader["Address"].ToString();
                            //eventModel.Lon = Convert.ToDecimal(oReader["Lon"]);
                            //eventModel.Lat = Convert.ToDecimal(oReader["Lat"]);
                            eventModel.About = oReader["About"].ToString();
                            eventModel.Cost = oReader["Cost"].ToString();

                            eventModel.Website = oReader["Website"].ToString();
                            eventModel.Image = oReader["Image"].ToString();
                            objViewEvents.lstAllEvents.Add(new EventModel
                            {
                                Feature = eventModel.Feature,
                                Type = eventModel.Type,
                                ECategory = eventModel.ECategory,
                                Date = eventModel.Date,
                                Place = eventModel.Place,
                                Address = eventModel.Address,
                                About = eventModel.About,
                                Image = eventModel.Image,
                                Cost = eventModel.Cost

                            });
                        }

                        myConnection.Close();
                    }
                }

            }
            catch (Exception ex)
            {

            }


            return View(objViewEvents);
        }
    }
}