using CSVApp.Contract.Entity;
using System.Collections.Generic;
using System.Linq;

namespace CSVApp.DAL.Utils {
    public class DataSeeder {
        #region first loade will add on DB this data
        
        public static void SeedCountryValues(ApplicationDbContext dbContext) {
            if (!dbContext.Countrys.Any()) {
                var countrysList = new List<Country> {
                    new Country() { Value = "Saint Kitts and Nevis "},
                    new Country() { Value = "Antigua and Barbuda "},
                    new Country() { Value = "Finland"},
                    new Country() { Value = "Sao Tome and Principe"},
                    new Country() { Value = "Rwanda"},
                    new Country() { Value = "South Korea"},
                    new Country() { Value = "Bahrain"},
                    new Country() { Value = "The Gambia"},
                    new Country() { Value = "Liberia"},
                    new Country() { Value = "Guatemala"},
                    new Country() { Value = "Andorra"},
                    new Country() { Value = "Macedonia"},
                    new Country() { Value = "Vietnam"},
                    new Country() { Value = "New Zealand"},
                    new Country() { Value = "Angola"},
                    new Country() { Value = "Uganda"},
                    new Country() { Value = "Nauru"},
                    new Country() { Value = "Monaco"},
                    new Country() { Value = "Egypt"},
                    new Country() { Value = "Kyrgyzstan"},
                    new Country() { Value = "Mali"},
                    new Country() { Value = "Italy"},
                    new Country() { Value = "Azerbaijan"},
                    new Country() { Value = "Guinea-Bissau"},
                    new Country() { Value = "Netherlands"},
                    new Country() { Value = "Palau"},
                    new Country() { Value = "United States of America"},
                    new Country() { Value = "Namibia"},
                    new Country() { Value = "Greenland"},
                    new Country() { Value = "Cameroon"},
                    new Country() { Value = "Jordan"},
                    new Country() { Value = "Madagascar"},
                    new Country() { Value = "Belarus"},
                    new Country() { Value = "Marshall Islands"},
                    new Country() { Value = "Malaysia"},
                    new Country() { Value = "San Marino"},
                    new Country() { Value = "Sri Lanka"},
                    new Country() { Value = "Indonesia"},
                    new Country() { Value = "Jamaica"},
                    new Country() { Value = "Uzbekistan"},
                    new Country() { Value = "Germany"},
                    new Country() { Value = "Philippines"},
                    new Country() { Value = "Cuba"},
                    new Country() { Value = "Lithuania"},
                    new Country() { Value = "Iceland"},
                    new Country() { Value = "Senegal"},
                    new Country() { Value = "Barbados"},
                    new Country() { Value = "Kuwait"},
                    new Country() { Value = "Hungary"},
                    new Country() { Value = "Cyprus"},
                    new Country() { Value = "Malawi"},
                    new Country() { Value = "Switzerland"},
                    new Country() { Value = "Estonia"},
                    new Country() { Value = "Algeria"},
                    new Country() { Value = "Comoros"},
                    new Country() { Value = "Nigeria"},
                    new Country() { Value = "Samoa "},
                    new Country() { Value = "El Salvador"},
                    new Country() { Value = "Federated States of Micronesia"},
                    new Country() { Value = "Malta"},
                    new Country() { Value = "Mongolia"},
                    new Country() { Value = "Bosnia and Herzegovina"},
                    new Country() { Value = "Ethiopia"},
                    new Country() { Value = "Lebanon"},
                    new Country() { Value = "Montenegro"},
                    new Country() { Value = "Saudi Arabia"},
                    new Country() { Value = "Iraq"},
                    new Country() { Value = "Laos"},
                    new Country() { Value = "Chad"},
                    new Country() { Value = "Australia"},
                    new Country() { Value = "Mauritius "},
                    new Country() { Value = "Kosovo"},
                    new Country() { Value = "Republic of the Congo"},
                    new Country() { Value = "Belize"},
                    new Country() { Value = "United Kingdom"},
                    new Country() { Value = "East Timor"},
                    new Country() { Value = "Mexico"},
                    new Country() { Value = "Albania"},
                    new Country() { Value = "Myanmar"},
                    new Country() { Value = "Sierra Leone"},
                    new Country() { Value = "Sweden"},
                    new Country() { Value = "Honduras"},
                    new Country() { Value = "Nicaragua"},
                    new Country() { Value = "Kenya"},
                    new Country() { Value = "Ukraine"},
                    new Country() { Value = "Trinidad and Tobago"},
                    new Country() { Value = "The Bahamas"},
                    new Country() { Value = "China"},
                    new Country() { Value = "Liechtenstein"},
                    new Country() { Value = "Fiji"},
                    new Country() { Value = "Solomon Islands"},
                    new Country() { Value = "Armenia"},
                    new Country() { Value = "Serbia"},
                    new Country() { Value = "Kiribati"},
                    new Country() { Value = "Democratic Republic of the Cong"},
                    new Country() { Value = "Libya"},
                    new Country() { Value = "India"},
                    new Country() { Value = "Burkina Faso"},
                    new Country() { Value = "Cote d'Ivoire"},
                    new Country() { Value = "Maldives"},
                    new Country() { Value = "Croatia"},
                    new Country() { Value = "Tuvalu"},
                    new Country() { Value = "Dominica"},
                    new Country() { Value = "Greece"},
                    new Country() { Value = "Botswana"},
                    new Country() { Value = "Austria"},
                    new Country() { Value = "United Arab Emirates"},
                    new Country() { Value = "Vatican City"},
                    new Country() { Value = "Equatorial Guinea"},
                    new Country() { Value = "Russia"},
                    new Country() { Value = "Israel"},
                    new Country() { Value = "Zimbabwe"},
                    new Country() { Value = "Qatar"},
                    new Country() { Value = "Swaziland"},
                    new Country() { Value = "Tonga"},
                    new Country() { Value = "Syria"},
                    new Country() { Value = "Poland"},
                    new Country() { Value = "Canada"},
                    new Country() { Value = "Bulgaria"},
                    new Country() { Value = "Afghanistan"},
                    new Country() { Value = "Togo"},
                    new Country() { Value = "Central African Republic"},
                    new Country() { Value = "Brunei"},
                    new Country() { Value = "Burundi"},
                    new Country() { Value = "Cape Verde"},
                    new Country() { Value = "Sudan"},
                    new Country() { Value = "Saint Vincent and the Grenadine"},
                    new Country() { Value = "South Sudan"},
                    new Country() { Value = "Slovenia"},
                    new Country() { Value = "Haiti"},
                    new Country() { Value = "Tunisia "},
                    new Country() { Value = "Moldova "},
                    new Country() { Value = "Latvia"},
                    new Country() { Value = "Ireland"},
                    new Country() { Value = "Slovakia"},
                    new Country() { Value = "Gabon"},
                    new Country() { Value = "Mozambique"},
                    new Country() { Value = "Somalia"},
                    new Country() { Value = "Guinea"},
                    new Country() { Value = "Thailand"},
                    new Country() { Value = "Norway"},
                    new Country() { Value = "France"},
                    new Country() { Value = "Grenada"},
                    new Country() { Value = "Benin"},
                    new Country() { Value = "Dominican Republic"},
                    new Country() { Value = "Luxembourg"},
                    new Country() { Value = "Belgium"},
                    new Country() { Value = "Turkmenistan"},
                    new Country() { Value = "Japan"},
                    new Country() { Value = "Bhutan"},
                    new Country() { Value = "Morocco"},
                    new Country() { Value = "Tajikistan"},
                    new Country() { Value = "Georgia"},
                    new Country() { Value = "Yemen"},
                    new Country() { Value = "Spain"},
                    new Country() { Value = "Oman"},
                    new Country() { Value = "Saint Lucia"},
                    new Country() { Value = "Papua New Guinea"},
                    new Country() { Value = "Turkey"},
                    new Country() { Value = "Eritrea"},
                    new Country() { Value = "Bangladesh"},
                    new Country() { Value = "Ghana"},
                    new Country() { Value = "Romania"},
                    new Country() { Value = "Pakistan"},
                    new Country() { Value = "Denmark"},
                    new Country() { Value = "Singapore"},
                    new Country() { Value = "Lesotho"},
                    new Country() { Value = "Panama"},
                    new Country() { Value = "Seychelles "},
                    new Country() { Value = "Cambodia"},
                    new Country() { Value = "Tanzania"},
                    new Country() { Value = "Niger"},
                    new Country() { Value = "Mauritania"},
                    new Country() { Value = "Iran"},
                    new Country() { Value = "Nepal"},
                    new Country() { Value = "South Africa"},
                    new Country() { Value = "Djibouti"},
                    new Country() { Value = "Czech Republic"},
                    new Country() { Value = "Zambia"},
                    new Country() { Value = "Portugal"},
                    new Country() { Value = "Taiwan"},
                    new Country() { Value = "Kazakhstan"},
                    new Country() { Value = "Costa Rica"},
                    new Country() { Value = "North Korea"},
                    new Country() { Value = "Vanuatu"}
                };

                foreach (var country in countrysList) {
                    dbContext.Countrys.Add(country);
                }

                dbContext.SaveChanges();
            }
        }

        public static void SeedItemTypeValues(ApplicationDbContext dbContext) {
            if (!dbContext.ItemTypes.Any()) {
                var countrysList = new List<ItemType> {
                    new ItemType() { Value = "Office Supplies"},
                    new ItemType() { Value = "Personal Care"},
                    new ItemType() { Value = "Cereal"},
                    new ItemType() { Value = "Baby Food"},
                    new ItemType() { Value = "Fruits"},
                    new ItemType() { Value = "Clothes"},
                    new ItemType() { Value = "Meat"},
                    new ItemType() { Value = "Household"},
                    new ItemType() { Value = "Beverages"},
                    new ItemType() { Value = "Cosmetics"},
                    new ItemType() { Value = "Vegetables"},
                    new ItemType() { Value = "Snacks"}
                };

                foreach (var country in countrysList) {
                    dbContext.ItemTypes.Add(country);
                }

                dbContext.SaveChanges();
            }
        }

        public static void SeedRegionValues(ApplicationDbContext dbContext) {
            if (!dbContext.Regions.Any()) {
                var countrysList = new List<Region> {
                    new Region() { Value = "North America"},
                    new Region() { Value = "Australia and Oceania"},
                    new Region() { Value = "Asia"},
                    new Region() { Value = "Central America and the Caribbean"},
                    new Region() { Value = "Middle East and North Africa"},
                    new Region() { Value = "Europe"},
                    new Region() { Value = "Sub-Saharan Africa"}
                };

                foreach (var country in countrysList) {
                    dbContext.Regions.Add(country);
                }

                dbContext.SaveChanges();
            }
        }

        public static void SeedSalesChannelValues(ApplicationDbContext dbContext) {
            if (!dbContext.SalesChannels.Any()) {
                    var countrysList = new List<SalesChannel> {
                    new SalesChannel() { Value = "Online"},
                    new SalesChannel() { Value = "Offline"}
                };

                foreach (var country in countrysList) {
                    dbContext.SalesChannels.Add(country);
                }

                dbContext.SaveChanges();
            }
        }

        #endregion
    }
}
