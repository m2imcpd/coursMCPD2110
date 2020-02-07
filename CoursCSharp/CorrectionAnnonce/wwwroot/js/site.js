const searchForm = document.querySelector("#searchForm");
const result = document.querySelector("#result");
searchForm.addEventListener("submit", function (e) {
    e.preventDefault();
    const data = {
        'categorie': document.querySelector("select[name='categorie']").value,
        'search': document.querySelector("input[name='search']").value
    };
    const url = this.getAttribute('action');
    fetch(url, {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(data)
    }).then(response => response.json()).then((res) => {
        result.innerHtml = "";
        for (let a of res) {
            //creation de la ligne
            let element = document.createElement('div');
            element.classList.add('row');
            //creation de l'image
            let img = document.createElement('img');
            img.attributes["src"] = a.image;
            img.classList.add('col');
            let titre = document.createElement('div').classList.add('col');
            titre.innerText = a.titre;
            let categorie = document.createElement('div').classList.add('col');
            categorie.innerText = a.categorie;
            let description = document.createElement('div').classList.add('col');
            description.innerText = a.description;
            let prix = document.createElement('div').classList.add('col');
            prix.innerText = a.prix;
            element.appendChild(img);
            element.appendChild(titre);
            element.appendChild(description);
            element.appendChild(prix);
            result.appendChild(element);
        }
    });
})