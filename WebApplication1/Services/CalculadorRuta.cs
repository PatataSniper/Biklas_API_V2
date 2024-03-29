﻿using System;
using System.IO;
using System.Diagnostics;
using System.Windows;
using Itinero;
using Itinero.LocalGeo;
using Itinero.IO.Osm;
using Itinero.Osm.Vehicles;

namespace Biklas_API_V2.Services
{
    public class CalculadorRuta : ICalculadorRuta
    {
        public Itinero.Route CalcularRutaOptima(Coordinate pIni, Coordinate pEnd, Stream mapa)
        {
            var routerDb = new RouterDb();
            routerDb.LoadOsmData(mapa, Vehicle.Bicycle);

            // create a router.
            var router = new Router(routerDb);

            // get a profile.
            var profile = Vehicle.Bicycle.Shortest();

            // create a routerpoint from a location.
            // snaps the given location to the nearest routable edge.
            RouterPoint start = router.Resolve(profile, pIni);
            RouterPoint end = router.Resolve(profile, pEnd);

            //var pruebaDijk = new Itinero.Algorithms.Default.Dykstra(routerDb)

            // calculate a route.
            Itinero.Route route = router.Calculate(profile, start, end);

            return route;
        }

        /// <summary>
        /// Obtiene un arreglo de coordenadas (ruta) interpretable por un mapa de Google
        /// Maps React a partir de un objeto 'Route'
        /// </summary>
        /// <param name="ruta">Objeto de ruta utilizado como origen de los datos (coordenadas)</param>
        /// <returns></returns>
        public object[] ObtenerFormaRutaGMR(Itinero.Route ruta)
        {
            // Convertimos cada punto o coordenada de un objeto de tipo 'Route' en un 
            // arreglo de coordenadas (ruta) interpretable por un mapa de google-maps-react.
            // Ejemplo: [{lat: 110.4567, lng: 99.5934}, {lat: 110.945712, lng: 98.87120}]
            return ruta.Shape.Select(c => new
            {
                // Utilizamos propiedades 'lat' y 'lng' como lo indica la documentación oficial
                // de la biblioteca JS 'Google Maps React': https://www.npmjs.com/package/google-maps-react
                lat = c.Latitude,
                lng = c.Longitude
            }).ToArray();
        }
    }
}