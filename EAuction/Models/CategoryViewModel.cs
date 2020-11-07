using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Models
{
    public class CategoryViewModel
    {

        public List<SelectListItem> Categories { get; set; }
        public CategoryViewModel()
        {

            var AntiqueGroup = new SelectListGroup { Name = "Antiques" };
            var ArtGroup = new SelectListGroup { Name = "Art" };
            var BooksGroup = new SelectListGroup { Name = "Books" };
            var CameraGroup = new SelectListGroup { Name = "Antiques" };

            var VehicleGroup = new SelectListGroup { Name = "Vehicles" };

            var ClothesGroup = new SelectListGroup { Name = "Clothes" };
            var ShoesGroup = new SelectListGroup { Name = "Shoes" };
            var AccessoriesGroup = new SelectListGroup { Name = "Accessories" };
            var DvdGroup = new SelectListGroup { Name = "DVDs" };
            var HealthGroup = new SelectListGroup { Name = "Health" };
            var MusicGroup = new SelectListGroup { Name = "Music" };
            var SportsGroup = new SelectListGroup { Name = "Sports" };
            var ToysGroup = new SelectListGroup { Name = "Toys" };
            var GamesGroup = new SelectListGroup { Name = "Video Games" };

            Categories = new List<SelectListItem> {
                new SelectListItem {

                    Text = "Antique Clocks",
                    Value = "Clocks",
                    Group = AntiqueGroup
                },
                new SelectListItem {
                    Text = "Antique Furniture",
                    Value = "Furniture",
                    Group = AntiqueGroup
                },
                new SelectListItem {
                    Value = "Antiquities",
                    Text = "Antiquities",
                    Group = AntiqueGroup
                },
                new SelectListItem {
                    Text = "Arhitectural Antiques",
                    Value = "Arhitectural",
                    Group = AntiqueGroup
                },
                new SelectListItem {
                    Text = "Asian/Oriental Antiques",
                    Value = "Oriental",
                    Group = AntiqueGroup
                },
                new SelectListItem {
                    Text = "Carpets & Rugs",
                    Value = "Carpets",
                    Group = AntiqueGroup
                },
                new SelectListItem {
                    Text = "Decorative Arts",
                    Value = "Decorative",
                    Group = AntiqueGroup
                },
                new SelectListItem {
                    Text = "Ethnographic Antiques",
                    Value = "Ethnographic",
                    Group = AntiqueGroup
                },
                new SelectListItem {
                    Value = "Manuscripts",
                    Text = "Manuscripts",
                    Group = AntiqueGroup
                },
                new SelectListItem {
                    Value = "Metalware",
                    Text = "Metalware",
                    Group = AntiqueGroup
                },
                new SelectListItem {
                    Text = "Other Antiques",
                    Value = "Other",
                    Group = AntiqueGroup
                },
                new SelectListItem {
                    Text = "Science",
                    Value = "Science",
                    Group = AntiqueGroup
                },
                new SelectListItem {
                    Text = "Silver",
                    Value = "Silver",
                    Group = AntiqueGroup
                },
                new SelectListItem {
                    Text = "Woodenware",
                    Value = "Woodenware",
                    Group = AntiqueGroup
                },

                 new SelectListItem {
                    Text = "Drawings",
                    Value = "Drawings",
                    Group = ArtGroup
                },
                  new SelectListItem {
                    Text = "Photographs",
                    Value = "Photographs",
                    Group = ArtGroup
                },
                   new SelectListItem {
                    Text = "Posters",
                    Value = "Posters",
                    Group = ArtGroup
                },
                new SelectListItem {
                    Text = "Sculptures",
                    Value = "Sculptures",
                    Group = ArtGroup
                },
                 new SelectListItem {
                    Text = "Other Art",
                    Value = "Other",
                    Group = ArtGroup
                },
                  new SelectListItem {
                    Text = "Paintings",
                    Value = "Paintings",
                    Group = ArtGroup
                },
                   new SelectListItem {
                    Text = "Accessories",
                    Value = "Accessories",
                    Group = BooksGroup
                },
                    new SelectListItem {
                    Text = "Audio Books",
                    Value = "Audio",
                    Group = BooksGroup
                },
                     new SelectListItem {
                    Text = "Calendars",
                    Value = "Calendars",
                    Group = BooksGroup
                },
                      new SelectListItem {
                    Text = "Comic Books",
                    Value = "Comics",
                    Group = BooksGroup
                },
                       new SelectListItem {
                    Text = "Fiction",
                    Value = "Fiction",
                    Group = BooksGroup
                },
                        new SelectListItem {
                    Text = "Magazines",
                    Value = "Magazines",
                    Group = BooksGroup
                },
                         new SelectListItem {
                    Text = "Non-Fiction",
                    Value = "NonFiction",
                    Group = BooksGroup
                },
                          new SelectListItem {
                    Text = "Other Books",
                    Value = "Other",
                    Group = BooksGroup
                },
                           new SelectListItem {
                    Text = "Camcorders",
                    Value = "Camcorders",
                    Group =CameraGroup
                },
                              new SelectListItem {
                    Text = "Digital Cameras",
                    Value = "Digital",
                    Group =CameraGroup
                },

                                 new SelectListItem {
                    Text = "Film Photography",
                    Value = "Film",
                    Group =CameraGroup
                },

                                    new SelectListItem {
                    Text = "Other Photography",
                    Value = "Other",
                    Group =CameraGroup
                },

                                       new SelectListItem {
                    Text = "Aircraft & Aviation",
                    Value = "Aircraft",
                    Group =VehicleGroup
                },
                  new SelectListItem {
                    Text = "Boats & Watercraft",
                    Value = "Boats",
                    Group =VehicleGroup
                },
                    new SelectListItem {
                    Text = "Cars",
                    Value = "Cars",
                    Group =VehicleGroup
                },
                      new SelectListItem {
                    Text = "Military Vehicles",
                    Value = "Military",
                    Group =VehicleGroup
                },
                        new SelectListItem {
                    Text = "Motorcycles",
                    Value = "Motorcycles",
                    Group =VehicleGroup
                },
                          new SelectListItem {
                    Text = "Other Vehicles",
                    Value = "Other ",
                    Group =VehicleGroup
                },
                            new SelectListItem {
                    Text = "Baby",
                    Value = "Baby",
                    Group =ClothesGroup
                },
                        new SelectListItem {
                    Text = "Kids",
                    Value = "Kids",
                    Group =ClothesGroup
                },
                        new SelectListItem {
                    Text = "Men",
                    Value = "Men",
                    Group =ClothesGroup
                },
                        new SelectListItem {
                    Text = "Women",
                    Value = "Women",
                    Group =ClothesGroup
                },

                          new SelectListItem {
                    Text = "Baby",
                    Value = "Baby",
                    Group =ShoesGroup
                },
                        new SelectListItem {
                    Text = "Kids",
                    Value = "Kids",
                    Group =ShoesGroup
                },
                        new SelectListItem {
                    Text = "Men",
                    Value = "Men",
                    Group =ShoesGroup
                },
                        new SelectListItem {
                    Text = "Women",
                    Value = "Women",
                    Group =ShoesGroup
                },

                          new SelectListItem {
                    Text = "Baby",
                    Value = "Baby",
                    Group =AccessoriesGroup
                },
                        new SelectListItem {
                    Text = "Kids",
                    Value = "Kids",
                    Group =AccessoriesGroup
                },
                        new SelectListItem {
                    Text = "Men",
                    Value = "Men",
                    Group =AccessoriesGroup
                },
                        new SelectListItem {
                    Text = "Women",
                    Value = "Women",
                    Group =AccessoriesGroup
                },
                     new SelectListItem {
                    Text = "DVDs & Blu-rays",
                    Value = "Dvd",
                    Group =DvdGroup
                },
                  new SelectListItem {
                    Text = "Laser Discs",
                    Value = "Laser Discs",
                    Group =DvdGroup
                },
                  new SelectListItem {
                    Text = "Other",
                    Value = "Other",
                    Group =DvdGroup
                },
                  new SelectListItem {
                    Text = "VHS",
                    Value = "VHS",
                    Group =DvdGroup
                },
                  new SelectListItem {
                    Text = "Bath & Body",
                    Value = "Bath",
                    Group =HealthGroup
                },
                    new SelectListItem {
                    Text = "E-Cigarettes &amp; Vapes",
                    Value = "Cigarettes",
                    Group =HealthGroup
                },
                  new SelectListItem {
                    Text = "Facial Skin Care",
                    Value = "Facial",
                    Group =HealthGroup
                },
                  new SelectListItem {
                    Text = "Fragrances",
                    Value = "Fragrances",
                    Group =HealthGroup
                },
                  new SelectListItem {
                    Text = "Make-up",
                    Value = "Makeup",
                    Group =HealthGroup
                },
                  new SelectListItem {
                    Text = "Massage",
                    Value = "Massage",
                    Group =HealthGroup
                },
                  new SelectListItem {
                    Text = "Oral Care",
                    Value = "Oral",
                    Group =HealthGroup
                },
                  new SelectListItem {
                    Text = "Other",
                    Value = "Other",
                    Group =HealthGroup
                },


                    new SelectListItem {
                    Text = "CDs",
                    Value = "Cds",
                    Group =MusicGroup
                },

                       new SelectListItem {
                    Text = "Cassettes",
                    Value = "Cassettes",
                    Group =MusicGroup
                },
                   new SelectListItem {
                    Text = "Other Formats",
                    Value = "Other",
                    Group =MusicGroup
                },
                   new SelectListItem {
                    Text = "Records",
                    Value = "Records",
                    Group =MusicGroup
                },
                   new SelectListItem {
                    Text = "Storage",
                    Value = "Storage",
                    Group =MusicGroup
                },
                   new SelectListItem {
                    Text = "American Football",
                    Value = "American",
                    Group =SportsGroup
                },
                   new SelectListItem {
                    Text = "Archery",
                    Value = "Archery",
                    Group =SportsGroup
                },
                   new SelectListItem {
                    Text = "Badminton",
                    Value = "Badminton",
                    Group =SportsGroup
                },
                   new SelectListItem {
                    Text = "Baseball",
                    Value = "Baseball",
                    Group =SportsGroup
                },
                   new SelectListItem {
                    Text = "Basketball",
                    Value = "Basketball",
                    Group =SportsGroup
                },
                   new SelectListItem {
                    Text = "Bowling",
                    Value = "Bowling",
                    Group =SportsGroup
                },
                   new SelectListItem {
                    Text = "Boxing",
                    Value = "Boxing",
                    Group =SportsGroup
                },
                   new SelectListItem {
                    Text = "Cricket",
                    Value = "Cricket",
                    Group =SportsGroup
                },
                   new SelectListItem {
                    Text = "Cycling",
                    Value = "Cycling",
                    Group =SportsGroup
                },
                   new SelectListItem {
                    Text = "Darts",
                    Value = "Darts",
                    Group =SportsGroup
                },
                    new SelectListItem {
                    Text = "Fishing",
                    Value = "Fishing",
                    Group =SportsGroup
                },
                    new SelectListItem {
                    Text = "Fitness",
                    Value = "Fitness",
                    Group =SportsGroup
                },
                    new SelectListItem {
                    Text = "Football",
                    Value = "Football",
                    Group =SportsGroup
                },
                    new SelectListItem {
                    Text = "Golf",
                    Value = "Golf",
                    Group =SportsGroup
                },

                 new SelectListItem {
                    Text = "Gymnastics",
                    Value = "Gymnastics",
                    Group =SportsGroup
                },
                 new SelectListItem {
                    Text = "Hockey",
                    Value = "Hockey",
                    Group =SportsGroup
                },
                 new SelectListItem {
                    Text = "Hunting",
                    Value = "Hunting",
                    Group =SportsGroup
                },
                 new SelectListItem {
                    Text = "Martial Arts",
                    Value = "Martial Arts",
                    Group =SportsGroup
                },
                   new SelectListItem {
                    Text = "Sailing",
                    Value = "Sailing",
                    Group =SportsGroup
                },
                  new SelectListItem {
                    Text = "Skateboarding",
                    Value = "Skateboarding",
                    Group =SportsGroup
                },
                  new SelectListItem {
                    Text = "Surfing",
                    Value = "Surfing",
                    Group =SportsGroup
                },
                  new SelectListItem {
                    Text = "Swimming",
                    Value = "Swimming",
                    Group =SportsGroup
                },
                     new SelectListItem {
                    Text = "Tennis",
                    Value = "Tennis",
                    Group =SportsGroup
                },

                        new SelectListItem {
                    Text = "Action Figures",
                    Value = "Action",
                    Group =ToysGroup
                },
                       new SelectListItem {
                    Text = "Beanies",
                    Value = "Beanies",
                    Group =ToysGroup
                },
                      new SelectListItem {
                    Text = "Education Toys",
                    Value = "Educational",
                    Group =ToysGroup
                },
                  new SelectListItem {
                    Text = "Electronic Pets",
                    Value = "Electronic",
                    Group =ToysGroup
                },
                  new SelectListItem {
                    Text = "Games",
                    Value = "Games",
                    Group =ToysGroup
                },
                  new SelectListItem {
                    Text = "Jigsaw & Puzzles",
                    Value = "Jigsaw",
                    Group =ToysGroup
                },
                  new SelectListItem {
                    Text = "Other",
                    Value = "Other",
                    Group =ToysGroup
                },
                     new SelectListItem {
                    Text = "Video Game Accessories",
                    Value = "Accessories",
                    Group =GamesGroup
                },
                   new SelectListItem {
                    Text = "Video Game Consoles",
                    Value = "Consoles",
                    Group =GamesGroup
                },
                   new SelectListItem {
                    Text = "Video Game Merchandise",
                    Value = "Merchandise",
                    Group =GamesGroup
                },
                   new SelectListItem {
                    Text = "Video Games ",
                    Value = "Video",
                    Group =GamesGroup
                }
      };
        }

      
    }

       

    }

