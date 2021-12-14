function AgregarCarrito(idProducto) {
    $.ajax({
        type: "POST",
        url: '/Carrito/AgregarCarrito',
        data:
        {
            idProducto: idProducto
        },
        dataType: 'json',
        success: function (data) {

            if (data == 1) {
                toastr.success('¡Ya no hay productos o hubo un error al agregar el producto!', "¡UPS!");
            } else {
                var Cantidad = parseFloat(document.getElementById('spanCantidad').innerHTML) + 1;
                document.getElementById('spanCantidad').innerHTML = Cantidad;

                $('#alertPrueba-' + idProducto).show('fade');
                setTimeout(function () {
                    $('#alertPrueba-' + idProducto).hide('fade');
                }, 4000);
                $('#cerrar').click(function () {

                    $('#alertPrueba-' + idProducto).hide('fade');

                });


                toastr.success('¡Producto agregado al carrito!', "Listo");
            }

        },
        error: function () {
            toastr.info('¡Producto no ha podido ser agregado al carrito!', "Error");

            setTimeout(function () {
                window.location.href = "/Login/IniciarSesion";
            }, 1500);


        }
    });
}


function ComprarProducto(idProducto) {
    window.location.href = "/Compra/CompraSinSesion?idProducto=" + idProducto;
}



function EliminarCarrito(idProducto) {
    $.ajax({
        type: "POST",
        url: '/Carrito/EliminarCarrito',
        data:
        {
            idProducto: idProducto,
        },
        dataType: 'json',
        success: function (data) {
            var Cantidad = parseFloat(document.getElementById('spanCantidad').innerHTML) - 1;

            if (Cantidad > -1) {
                document.getElementById('spanCantidad').innerHTML = Cantidad;
            }

            toastr.info('¡Producto eliminado del carrito!', "Listo");

            setTimeout(function () {
                location.reload();
            }, 1500);
            /*   crearEntradaLog('Producto eliminado del carrito');*/
        },
        error: function (data) {
            toastr.info('¡Producto no ha podido ser eliminado del carrito!', "Error");

            setTimeout(function () {
                location.reload();
            }, 1500);
        }
    });
}