using System;
using System.Collections.Generic;
using System.Text;

namespace LunchBoxApp
{
    public class Constants
    {
        public string url = "http://172.31.37.42:8080/api/";
        //public string url = "http://172.31.37.56:8080/api/";
        /// <summary>
        /// Broodjes
        /// </summary>
        public Guid Category1Guid = new Guid("4f7062d2-ff2b-4838-a104-713ebb2f9eb2");
        /// <summary>
        /// Salades, pastas & snacks
        /// </summary>
        public Guid Category2Guid = new Guid("b2a41187-60b8-4281-aadc-775d28116c13");
        /// <summary>
        /// Dessert & ontbijt
        /// </summary>
        public Guid Category3Guid = new Guid("366b3846-29e1-407e-bea0-20e50ce5501c");
        /// <summary>
        /// Dranken
        /// </summary>
        public Guid Category4Guid = new Guid("88ebe7d6-80de-47b8-893b-1bf3dbaaf5f7");

        /// <summary>
        /// Broodjes, Kaas
        /// </summary>
        public Guid Subcategory1Guid = new Guid("1799200a-fc69-4bde-85c6-30c1fa4d7330");
        /// <summary>
        /// Broodjes, Vis
        /// </summary>
        public Guid Subcategory2Guid = new Guid("bd297028-b0ba-4330-90a6-8b1286f76792");
        /// <summary>
        /// Broodjes, Vlees
        /// </summary>
        public Guid Subcategory3Guid = new Guid("e9a6293c-1b66-4d44-9c4f-e587f27e1c4c");
        /// <summary>
        /// Broodjes, Kip
        /// </summary>
        public Guid Subcategory4Guid = new Guid("c4b05db3-0f2f-413e-8e7a-b3ffa43774b5");

        /// <summary>
        /// Salades, pastas & snacks, Panini's
        /// </summary>
        public Guid Subcategory5Guid = new Guid("459cc801-fa50-48bf-9fce-76b68c7d31bb");
        /// <summary>
        /// Salades, pastas & snacks, Salades
        /// </summary>
        public Guid Subcategory6Guid = new Guid("d4a8ced1-d7db-4f58-a720-1e792fba3a0a");
        /// <summary>
        /// Salades, pastas & snacks, Pasta's
        /// </summary>
        public Guid Subcategory7Guid = new Guid("4df683c2-4187-499f-a46b-b2d85ba14ba9");
        /// <summary>
        /// Salades, pastas & snacks, Snacks
        /// </summary>
        public Guid Subcategory8Guid = new Guid("8b8aa0c8-40ec-4c8c-8bd0-8cf7a7accd00");

        /// <summary>
        /// Desert & ontbijt, Dessert
        /// </summary>
        public Guid Subcategory9Guid = new Guid("0f6fa255-f3ac-417d-ba2f-10419ce7fbb9");
        /// <summary>
        /// Desert & ontbijt, Ontbijt
        /// </summary>
        public Guid Subcategory10Guid = new Guid("e0dcf081-47bd-4b34-bcdb-8621dfa4a651");
        
        /// <summary>
        /// Dranken, Warme dranken
        /// </summary>
        public Guid Subcategory11Guid = new Guid("f81ed999-b2d3-40ea-bda3-350066016da1");




    }
}
