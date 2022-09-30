////function miAjaxMvc(param) {
////    var apiUrl = 'https://localhost:44334/Api/Empleados/';

////    if (param > 0) {
////        apiUrl = apiUrl + "/" + param;
////        //llamamos a un objeto de la librería jQuery y le pasamos la apiUrl
////        $.ajax(
////            {
////                //parámetros de configuración del objeto Ajax de jQuery
////                type: "GET", //HTTP GET Method
////                url: apiUrl//, // Controller/View
////                //data: No es necesario: Es GET
////                //el objeto nos muestra lo que le ha devuelto la api como parámetro: "res"
////            }).done(function (res) {
////                //Enviamos el jSon "res" al EmpleadosMvcController
////                //método: _EmpleadoMvcPartialView(res)
////                $.ajax(
////                    {
////                        type: "POST", //HTTP POST Method
////                        //url: "../_EmpleadoMvcPartialView", // Controller/View
////                        url: "_EmpleadoMvcPartialView", // Controller/View
////                        data: res
////                        //Nos devuelve una respuesta "resDeLaRes"
////                        //Que es un string con el html de la vista _EmpleadoMvcPartialView
////                    }).done(function (resDeLaRes) {
////                        //Cargamos la Vista Html dentro del <div>
////                        $('#EmpleadoMvcPartialView').empty().append(resDeLaRes);
////                    }).fail(function (resDeLaRes) {
////                        console.log(resDeLaRes);
////                    }).always(function (resDeLaRes) {
////                        console.log(resDeLaRes);
////                    });
////            }).fail(function (res) {
////                console.log(res);
////            }).always(function (res) {
////                console.log(res);
////            });
////    }
////}