using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentScanner
{
    public class Templates
    {
        public static string binary = @"{
        ""GlobalParameter"":{
            ""Name"":""GP""
        },
        ""ImageParameterArray"":[
            {
                ""Name"":""IP-1"",
                ""NormalizerParameterName"":""NP-1""
            }
        ],
        ""NormalizerParameterArray"":[
            {
                ""Name"":""NP-1"",
                ""ColourMode"": ""ICM_BINARY"" 
            }
        ]
    }";

        public static string color = @"{
        ""GlobalParameter"":{
            ""Name"":""GP""
        },
        ""ImageParameterArray"":[
            {
                ""Name"":""IP-1"",
                ""NormalizerParameterName"":""NP-1""
            }
        ],
        ""NormalizerParameterArray"":[
            {
                ""Name"":""NP-1"",
                ""ColourMode"": ""ICM_COLOUR"" 
            }
        ]
    }";

        public static string grayscale = @"{
        ""GlobalParameter"":{
            ""Name"":""GP""
        },
        ""ImageParameterArray"":[
            {
                ""Name"":""IP-1"",
                ""NormalizerParameterName"":""NP-1""
            }
        ],
        ""NormalizerParameterArray"":[
            {
                ""Name"":""NP-1"",
                ""ColourMode"": ""ICM_GRAYSCALE"" 
            }
        ]
    }";
    }
}
