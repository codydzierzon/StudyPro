

document.addEventListener('DOMContentLoaded', () => {
    const updateButton = document.getElementById('editButton')
    updateButton.addEventListener('click', updateCard)

    const deleteButton = document.getElementById("trash")
    deleteButton.addEventListener('click', deleteForm)

    const uploadButton = document.getElementById("uploadButton")
    uploadButton.addEventListener('click', uploadImage)
})

function updateCard(event) {
    event.preventDefault()
    const id = document.getElementById('cardId').value
    const url = `/api/cards/edit/${id}`
    const cardTerm = document.getElementById('newTerm').value
    const cardLevel = document.getElementById('selectLevel').value
    const cardCategory = document.getElementById('selectCategory').value
    const cardDefinition = document.getElementById('newDefinition').value
    const imageUpload = document.getElementById('inputGroupFile01').value
    const card = {
        cardID: id,
        categoryID: cardCategory,
        term: cardTerm,
        level: cardLevel,
        definition: cardDefinition,
        imagePath: imageUpload
    }
    axios.put(url, card)
        .then(response => {

            window.location.href = `/categories/details/${cardCategory}?updated-card=${cardTerm}`
            
        })
}
function deleteForm() {
    const id = document.getElementById('deleteCard')
    id.classList.remove("d-none")

    const deleteButtonCancel = document.getElementById("trashCancel")
    deleteButtonCancel.addEventListener('click', () => {
        id.classList.add("d-none")
    })
    const deleteButtonConfirm = document.getElementById("trashConfirm")
    deleteButtonConfirm.addEventListener('click', deleteCard)
}
function deleteCard() {
    const id = document.getElementById('cardId').value
    const url = `/api/cards/edit/${id}`
    const cardCategory = document.getElementById('selectCategory').value
    const cardTerm = document.getElementById('newTerm').value
    axios.delete(url)
        .then(response => {
            window.location.href = `/categories/details/${cardCategory}?deleted-card=${cardTerm}`
        })
}
function uploadImage(event) {
    event.preventDefault()
    const id = document.getElementById('cardId').value
    const uploader = document.getElementById("inputGroupFile01")
    const url = `/cards/upload/${id}`

    const files = uploader.files
    const formData = new FormData()
    formData.append('file', files[0]);

    axios.post(url, formData, {
        headers: {
            "Content-Type": "multipart/form-data"
        }
    })
        .then(response => {
            const cardImage = document.getElementById("cardImage")
            cardImage.src = response.data;
            uploader.value = null;
        })
        .catch(error => {
            console.log(error)
        })
}