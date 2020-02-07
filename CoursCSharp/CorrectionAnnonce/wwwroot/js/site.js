const searchForm = document.querySelector("#searchForm");
const result = document.querySelector("#result");
if (searchForm !== null) {
    searchForm.addEventListener("submit", function (e) {
    e.preventDefault();
    result.innerHTML = '<div class="spinner-border justify-content-center align-items-center" role="status"><span class="sr-only text-center" > Loading...</span ></div>';
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
        result.innerHTML = "";
        for (let a of res) {
            console.log(a);
            //creation de la ligne
            let element = document.createElement('div');
            element.classList.add('row');
            element.classList.add('annonce');
            //creation de l'image
            let img = document.createElement('img');
            img.setAttribute("src", a.image);
            img.classList.add('col');
            let bloc = document.createElement('div');
            bloc.classList.add('col-8');

            let titre = document.createElement('div');
            titre.classList.add('row');
            titre.innerText = a.titre;
            let categorie = document.createElement('div');
            categorie.classList.add('col');
            categorie.innerText = a.categorie;
            let description = document.createElement('div');
            description.classList.add('row');
            description.innerText = a.description;
            bloc.appendChild(titre);
            bloc.appendChild(description);
            let prix = document.createElement('div');
            let detail = document.createElement('a');
            detail.classList.add("row");
            detail.classList.add("btn");
            detail.classList.add("btn-default");
            detail.setAttribute("href", "annonce/detail/" + a.id);
            detail.innerHTML = "Detail";
            bloc.appendChild(detail);
            prix.classList.add('col');
            prix.innerText = a.prix;
            element.appendChild(img);
            element.appendChild(bloc);
            element.appendChild(prix);
            result.appendChild(element);
        }
    });
});
}

const detail = document.querySelector("#detail");
if (detail !== null) {
    detail.addEventListener('click', function (e) {
        e.preventDefault();
        const url = this.getAttribute("href");
        fetch(url, {
            'method': 'GET'
        }).then((response) => response.json()).then((res) => {
            alert(res.message);
        });
    })
}
