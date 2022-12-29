const cardsBaseUrl = `/cards/`
const cardsApiBaseUrl = `/api/cards/`
let uploadBtn = false


document.addEventListener('DOMContentLoaded', () => {
    displayCardsByCategory();
    //getAllCards();
    const addCardButton = document.getElementById("newTermButton")
    addCardButton.addEventListener('click', addCard)
    const newTermUploadBtn = document.getElementById("newTermAndUploadButton")
    newTermUploadBtn.addEventListener('click', saveAndUpload)

    const showFormButton = document.getElementById("showFormButton")
    showFormButton.addEventListener('click', () => {
        const showForm = document.getElementById("showForm")
        if (showForm.classList.contains('d-none')) {
            showForm.classList.remove('d-none');
            showFormButton.innerText = "Hide Form"
        }
        else {
            showForm.classList.add('d-none');
            showFormButton.innerText = "Add Card"
        }
    })
    let cardTitle = getParameterByName('updated-card')
    let deleteTitle = getParameterByName('deleted-card')
    if (cardTitle) {
        const term = document.getElementById('cardTitle')
        term.innerText = cardTitle
        const x = document.getElementById("snackbar");
        x.classList.add("show");
        setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
    }
    if (deleteTitle) {
        const term = document.getElementById('deleteTitle')
        term.innerText = deleteTitle
        const x = document.getElementById("snackbarDelete");
        x.classList.add("show");
        setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
    }
});

function getParameterByName(name, url = window.location.href) {
    name = name.replace(/[\[\]]/g, '\\$&');
    const regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

function getAllCards() {
    const url = cardsApiBaseUrl

    axios.get(url)
        .then(response => {

            const cards = response.data
            displayCards(cards)

        })
}

function displayCards(cards) {
    cards.forEach((card) => {
        displayCard(card)
    });

}

function displayCard(card) {
    const container = document.getElementById("card-container")
    const cardMain = document.createElement('div')
    cardMain.classList.add("card")
    cardMain.classList.add("text-white")
    cardMain.classList.add("mb-3")
    const cardFront = document.createElement('div')
    cardFront.classList.add("front")
    const cardBack = document.createElement('div')
    cardBack.classList.add("back")
    const cardHeader = document.createElement('div')
    cardHeader.classList.add('card-header')
    const cardBody = document.createElement('div')
    cardBody.classList.add('card-body')
    if (card.imagePath != null) {

        const cardImage = document.createElement('img')
        cardImage.src = card.imagePath
        cardImage.classList.add("imageAdd")
        cardBody.appendChild(cardImage)
    }
    const p = document.createElement('p')
    p.classList.add('card-text')
    const cardLevel = document.createElement('p')
    if (card.level === 1) {
        cardLevel.innerHTML = '<i class="fa-regular fa-star"></i>'
    }
    else if (card.level === 2) {
        cardLevel.innerHTML = '<i class="fa-solid fa-star-half-stroke"></i>'
    }
    else {
        cardLevel.innerHTML = '<i class="fa-solid fa-star"></i>'
    }
    cardLevel.classList.add('star')

    const cardH = document.createElement('h4')
    cardH.classList.add('cardH4')
    cardH.innerText = card.term
    const pencil = document.createElement("p")
    pencil.innerHTML = '<i id="pencil" class="fa-sharp fa-solid fa-pencil"></i>'
    pencil.classList.add("btn")
    pencil.classList.add("pencilBtn")
    



    cardHeader.innerText = card.term
    cardMain.appendChild(cardFront)
    cardMain.appendChild(cardBack)
    p.innerText = card.definition
    cardBack.appendChild(cardHeader)
    cardBack.appendChild(cardBody)
    //if (card.imagePath != null) {
    //    cardBody.appendChild(cardImage)
    //}
    cardBody.appendChild(p)
    container.appendChild(cardMain)
    cardFront.appendChild(cardLevel)
    cardFront.appendChild(cardH)
    cardFront.appendChild(pencil)
    cardMain.addEventListener("click", () => {
        cardMain.classList.toggle("flipCard")
    })
    pencil.addEventListener("click", () => {
        window.location.href = `/cards/edit/${card.cardID}`
    })
}

function displayCardsByCategory() {
    const path = window.location.href
    const index = path.lastIndexOf('/')
    const id = path.substring(index + 1)
    const url = `${cardsApiBaseUrl}${id}`
    axios.get(url)
        .then(response => {
            const cards = response.data
            displayCards(cards)
        })
}

function addCard() {
    const cardName = document.getElementById("newTerm").value
    const cardLevel = document.getElementById("selectLevel").value
    const cardCategory = document.getElementById("selectCategory").value
    const cardDefinition = document.getElementById("newDefinition").value

    const card = {
        categoryID: cardCategory,
        term: cardName,
        level: cardLevel,
        definition: cardDefinition
    }
    const url = cardsApiBaseUrl
    axios.post(url, card)
        .then(response => {
            const newCard = response.data;
            if (uploadBtn == true) {
                uploadBtn = false
                window.location.href = `/cards/edit/${newCard.cardID}`
            }
            else {
                displayCard(newCard)
                const cardField = document.getElementById("newTerm")
                cardField.value = '';
                const cardFieldDef = document.getElementById("newDefinition")
                cardFieldDef.value = '';
            }
        })
}

function saveAndUpload() {
    uploadBtn = true;
    addCard()
    //window.location.href = `/cards/edit/${card.cardID}`
}

