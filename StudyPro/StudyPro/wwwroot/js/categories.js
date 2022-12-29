//const { default: axios } = require("../../../node_modules/axios/index")
const categoriesBaseUrl = "/categories/"
const categoriesApiBaseUrl = "/api/categories/"

document.addEventListener('DOMContentLoaded', () => {

    getAllCategories()

    const addCategoryButton = document.getElementById("addCategoryButton")
    addCategoryButton.addEventListener('click', addCategory)
    
})


function getAllCategories() {
    const url = categoriesApiBaseUrl

    axios.get(url)
        .then(response => {

            const categories = response.data
            displayCategories(categories)
        })
}

function displayCategories(categories) {
    const container = document.getElementById("card-container")
    categories.forEach((card) => {
        createCard(card)
    })
}

function addCategory() {
    const categoryName = document.getElementById("addCategory").value
    const category = {
        categoryName: categoryName
        }
    const url = categoriesApiBaseUrl
    axios.post(url, category)
        .then(response => {
            const newCategory = response.data;
            createCard(newCategory);
            const categoryField = document.getElementById("addCategory")
            categoryField.value = '';
        })

}



function createCard(card) {
    const id = card.categoryID
    const url = `${categoriesBaseUrl}details/${id}`

    console.log(id)
    const container = document.getElementById("card-container")
    const cardLink = document.createElement('a')
    cardLink.classList.add('front')
    const cardMain = document.createElement('div')
    cardMain.classList.add("card")
    cardMain.classList.add("text-white")
    cardMain.classList.add("mb-3")
    const cardFront = document.createElement('div')
    cardFront.classList.add("front")
    const cardH = document.createElement('h4')
    cardH.innerText = card.categoryName
    cardLink.href = url
    cardLink.style.textDecoration = 'none'

    cardMain.appendChild(cardLink)
    container.appendChild(cardMain)
    cardFront.appendChild(cardH)
    cardLink.appendChild(cardFront)
}