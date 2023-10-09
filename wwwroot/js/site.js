// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function ValidarContraseña(){
    const contraseña1 = document.getElementById('contraseña1').value;
    const contraseña2 = document.getElementById('contraseña2').value; 
    const caracteresEspeciales = ['!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '-', '{', '}', '\\', '[', ']', '|', '°', ':', ';', '<', '>', ',', '.', '?', '~'];
    let contieneCaracterEspecial = false;
    
    let contieneMayuscula = false;

    for (let i = 0; i < contraseña1.length; i++) {
        if (contraseña1[i] !== contraseña1[i].toLowerCase()) {
            contieneMayuscula = true;
            break;
        }
    }

    for (let i = 0; i < caracteresEspeciales.length; i++) {
        if (contraseña1.includes(caracteresEspeciales[i])) {
            contieneCaracterEspecial = true;
            break;
        }
    }
    if (contraseña1 === contraseña2 && contraseña1.length >= 8 && contieneCaracterEspecial == true) {
        return true;
    }
    if(contraseña1 !== contraseña2)
    {
        alert("Las contraseñas no coinciden.");
        console.log("Las contraseñas no coinciden.")
        return false;
       
    }
    if(contraseña1.length <8 || contraseña2.length <8 ){
        alert("La contraseña debe ser mayor a 8 caracteres.");
        return false;
    }
    if(!contieneCaracterEspecial){
        alert("La contraseña debe tener al menos un caracter especial.");
        return false
    }
    if (!contieneMayuscula) { //este no anda. 
        alert("La contraseña debe contener al menos una letra mayúscula.");
        console.log("La contraseña debe contener al menos una letra mayúscula.");
        return false
    }
}