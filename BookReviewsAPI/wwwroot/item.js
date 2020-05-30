const itemUrl = 'api/reviews/'

function onLoad() {
    var id = window.location.href.split("?")[1];

    fetch(itemUrl + id)
    .then(response => response.json())
    .then(data => _displayItem(data))
    .catch(error => console.error('Unable to get item.', error));
}

function _displayItem(data){
    const tBody = document.getElementById('container');

    var img = document.getElementById('Img');
    img.src = data.img;

    var button = document.getElementById('Button');
    button.href = data.button;

    var bookName = document.getElementById('BookName');
    bookName.innerText = data.bookName;

    document.getElementById('AuthorName').innerText = data.authorName;

    document.getElementById('Review').innerText = data.review;
}