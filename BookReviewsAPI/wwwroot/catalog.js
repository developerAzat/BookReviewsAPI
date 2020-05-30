const catalogUrl = 'api/categories';

function getCategories() {
    fetch(catalogUrl)
      .then(response => response.json())
      .then(data => _displayCategories(data))
      .catch(error => console.error('Unable to get categories.', error));
  }

function categoryClick(id) {

    var activeCategory = document.getElementsByClassName('nav-item active category');
    activeCategory[0].classList.remove('active');


    var newActiveCategory = document.getElementById(id);
    newActiveCategory.className = 'nav-item active category';


    var category = '';
    if(id == 0){
        category = uri;
    }
    else {
        category = catalogUrl + '/' + id;
    }

    fetch(category)
      .then(response => response.json())
      .then(data => _displayItems(data))
      .catch(error => console.error('Unable to get categories.', error));
}

function _displayCategories(data) {
    const menu = document.getElementById('menu-ul');


    data.forEach(category => {
        var navItem = document.createElement('li');
        navItem.className = 'nav-item category';
        navItem.id = category.categoryID;
        navItem.setAttribute('onClick',`categoryClick(${navItem.id})`)

        var itemSpan = document.createElement('span');
        itemSpan.className = 'nav-link';
        itemSpan.innerText = category.name;

        navItem.appendChild(itemSpan);

        menu.appendChild(navItem);
    });

}

