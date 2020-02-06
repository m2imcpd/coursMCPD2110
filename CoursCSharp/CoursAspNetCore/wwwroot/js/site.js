// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const div = document.querySelector("#monForm");

div.addEventListener('submit', function (e) {
    e.preventDefault();
    const data = {
        "nom": document.querySelector("input[name='nom']").value,
        "prenom": document.querySelector("input[name='prenom']").value
    };
    const url = this.getAttribute("action");
    fetch(url, {
        method: "POST",
        headers: {
            "Content-type": "application/json"
        },
        body: JSON.stringify(data)
    }).then(res => {
        let response = res.json();
        response.then(data => {
            const section = document.querySelector("#content");
            section.innerHTML += '<section class="row"><div class="col">' + data.nom + '</div> <div class="col">' + data.prenom + '</div></section>';
            console.log(data);
        });
    });
});