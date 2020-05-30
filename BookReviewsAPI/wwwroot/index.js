const uri = 'api/books';

function getItems() {
  fetch(uri)
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error('Unable to get items.', error));
}

function _displayItems(data) {
    const tBody = document.getElementById('container');

    while(tBody.firstChild){
        tBody.removeChild(tBody.firstChild);
    }

    tBody.innerHTML = '';
  
    var countElement = 0;
    var countRows = 0;

    data.forEach(item => {
      if(countElement == 0) {
          var newRow = document.createElement('div');
          newRow.className = 'row';
          newRow.id = 'row' + countRows;
          tBody.appendChild(newRow);
      }
        var row = document.getElementById('row' + countRows);
        var element = document.createElement('div');
        element.className = 'col-md-3'      
        var img = document.createElement('img');
        img.className = 'img-fluid';
        img.src = item.img      
        var description = document.createElement('h4');
        description.innerText = item.name       
        element.appendChild(img);
        element.appendChild(description)        
        row.appendChild(element);

        countElement++;
        if(countElement == 4){
            countElement = 0;
            countRows++;
        }
    });
  }

