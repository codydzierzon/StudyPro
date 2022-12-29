
function upload()
{
    const uploader = document.getElementById("fileUpload")
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
            loadThumbnails()
        })
        .catch(error => {
            console.log(error)
        })
}

function loadThumbnails() {
    const url = '/home/images'

    axios.get(url).then(response => {
        const thumbs = document.getElementById('thumbs')
        thumbs.innerHTML = response.data
    })
}


function loadThumbnails2() {
    const url = '/api/images'

    axios.get(url).then(response => {
        const thumbs = document.getElementById('thumbs')
        thumbs.innerHTML = ''
        response.data.forEach(image => {
            const img = document.createElement('img')
            img.src = image

            thumbs.appendChild(img)
        });
    })
}



document.addEventListener('DOMContentLoaded', () => {

    const submit = document.getElementById('btnUpload')
    submit.addEventListener('click', upload)

    loadThumbnails()
})