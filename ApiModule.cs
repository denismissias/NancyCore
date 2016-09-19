using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Threading;

namespace TestApiNancy
{
    public class ApiModule : NancyModule
    {
        public ApiModule()
        {
            Get("/api/values", parameters =>
            {
                Thread.Sleep(1000);
                return "Processou o Get depois de 1 segundo.";
            });

            Get("/api/values/{id}", parameters =>
            {
                Thread.Sleep(1000);
                List<Feature> features = new List<Feature>();

                features.Add(new Feature()
                {
                    Id = "89981d318e7f4fa9bf267e5498ac6688",
                    PluginId = "c8f1a098ef6e42ff95b646d2a1382747",
                    PluginTypeId = 1,
                    FolderName = "cvcviagens",
                    Version = "20160629155603000000"
                });

                features.Add(new Feature()
                {
                    Id = "ce48903b935c436f8c696585e8df1f36",
                    PluginTypeId = 0,
                    FolderName = "cvcviagens"
                });

                List<String> urls = new List<string>();

                urls.Add("https://www.cvc.com.br/travel/confirmacao");
                urls.Add("https://www.cvc.com.br/travel/confirmacao.aspx");

                Teste featuer = new Teste()
                {
                    Id = parameters.id,
                    AppId = "1566050816982327",
                    Name = "CVC Viagens",
                    CustomDNS = "cvc",
                    ForceRedirect = true,
                    GaEnabled = true,
                    Features = features,
                    PurchaseUrl = urls
                };

                return Response.AsJson(featuer);
            });

            Post("/api/values", parameters =>
            {
                Thread.Sleep(1000);
                Teste modelBinding = this.Bind();

                Guid testeGuid;
                Boolean isGuid = Guid.TryParse(modelBinding.Id, out testeGuid);

                if (!isGuid)
                {
                    return HttpStatusCode.BadRequest;
                }

                return HttpStatusCode.OK;
            });
        }
    }
}
