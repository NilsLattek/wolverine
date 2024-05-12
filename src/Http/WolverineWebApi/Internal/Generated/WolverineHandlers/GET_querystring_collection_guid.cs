// <auto-generated/>
#pragma warning disable
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using Wolverine.Http;

namespace Internal.Generated.WolverineHandlers
{
    // START: GET_querystring_collection_guid
    public class GET_querystring_collection_guid : Wolverine.Http.HttpHandler
    {
        private readonly Wolverine.Http.WolverineHttpOptions _wolverineHttpOptions;

        public GET_querystring_collection_guid(Wolverine.Http.WolverineHttpOptions wolverineHttpOptions) : base(wolverineHttpOptions)
        {
            _wolverineHttpOptions = wolverineHttpOptions;
        }

        public override async System.Threading.Tasks.Task Handle(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            var collection = new System.Collections.Generic.List<System.Guid>();
            foreach (var collectionValue in httpContext.Request.Query["collection"])
            {
                if (System.Guid.TryParse(collectionValue, System.Globalization.CultureInfo.InvariantCulture, out var collectionValueParsed))
                {
                    collection.Add(collectionValueParsed);
                }
            }
            
            // The actual HTTP request handler execution
            var result_of_UsingGuidCollection = WolverineWebApi.QuerystringCollectionEndpoints.UsingGuidCollection(collection);

            await WriteString(httpContext, result_of_UsingGuidCollection);
        }
    }

    // END: GET_querystring_collection_guid
    
    
}