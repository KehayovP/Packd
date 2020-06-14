window.onload = function () {

    let _NewCategoryButtonClick = 0;
    let _NewItemButtonClick = 0;
    let _NewDefaultCategoryButtonClick = 0;
    let _NewDefaultItemButtonClick = 0;

    // Set Display Properties on divs depending on state
    $('#NewListNameFieldDiv').css('display', 'block');
    $('#NewListContent').css('display', 'none');
    $('#NewCategoryDiv').css('display', 'none');
    $('#SaveListDiv').css('display', 'none');

    // Create New List Button Handler
    $('#CreateNewListButton').unbind().click(function () {
        if ($('#NewListNameField').val() != "") {
            $('#NewListName').html($('#NewListNameField').val());
            $('#NewListNameFieldDiv').css('display', 'none');
            $('#NewListContent').css('display', 'block');
            $('#NewCategoryDiv').css('display', 'block');
        }
    });

    // Create New Custom Category Button Handler
    $('#CreateNewCategoryButton').unbind().click(function (event) {
        event.stopPropagation();

        if ($('#NewCategoryField').val() != "" && AllCategoriesNamesNewList.indexOf($('#NewCategoryField').val()) == -1) {
            let ul = '<div id="temp-category-' + _NewCategoryButtonClick + '"><ul class="list-group w-75 mr-auto ml-auto" id="custom-' + _NewCategoryButtonClick + '">';
            ul += '<li id ="temp-category-' + _NewCategoryButtonClick + '" class="list-group-item active category-li" >' + $('#NewCategoryField').val() + '<input class="float-right remove-custom-category btn btn-danger" type="button" value="x"></li ></ul>';
            ul += '<div class="input-group mb-3  w-75 mr-auto ml-auto">';
            ul += '     <input type="text" class="form-control add-item-field" placeholder="Add item to category...">';
            ul += '     <div class="input-group-append">';
            ul += '         <button class="btn btn-outline-secondary add-item-button" type="button">Add</button>';
            ul += '     </div>';
            ul += '</div>';
            ul += '<br /><br /></div>';

            $('#CustomCategories').append(ul);
            AllCategoriesNamesNewList.push($('#NewCategoryField').val());
            $('#NewCategoryField').val('');

            var CategoryId = '#temp-category-' + _NewCategoryButtonClick + ' .add-item-button';
            RemoveCustomCategoryEventHandler(AllCategoriesNamesNewList);

            // Add Custom Item Event Handler 
            $(CategoryId).unbind().click(function (event) {
                event.stopPropagation();
                let newItemName = event.currentTarget.parentNode.parentNode.childNodes[0].nextSibling.value;

                if (newItemName != "") {
                    let newItemLiElement = "<li id='custom-item-" + _NewItemButtonClick + "' class='list-group-item item-li'>" + newItemName + "<input class='float-right remove-custom-item  btn btn-danger' type='button' value='x'></li>";

                    let newLi = event.currentTarget.parentNode.parentNode.parentNode.children[0].insertAdjacentHTML("beforeend", newItemLiElement);

                    event.currentTarget.parentNode.parentNode.childNodes[0].nextSibling.value = "";
                    _NewItemButtonClick++;
                    RemoveCustomItemEventHandler();
                }
            });

            _NewCategoryButtonClick++;
        }

        if (AtLeastOneCategoryAndOneItemExists)
            AllowSave();
    });

    // Add Default Item to Custom list event handler
    $('.add-default-item').unbind().click(function (event) {
        event.stopPropagation();
        let SelectedItemName = event.currentTarget.parentElement.innerText;
        let SelectedItemNameId = event.currentTarget.parentElement.getAttribute('id');
        let SelectedItemCategory = event.currentTarget.parentElement.parentElement.firstElementChild.innerText;
        let SelectedItemCategoryId = event.currentTarget.parentElement.parentElement.firstElementChild.getAttribute('id');

        if ($('#NewListName').html() != "") {

            // If Category does not exist, add Category and Item
            if (AllCategoriesNamesNewList.indexOf(SelectedItemCategory) == -1) {
                let ul = '<div id="default-custom-category-' + SelectedItemCategoryId + '"><ul class="list-group w-75 mr-auto ml-auto" id="default-custom-' + SelectedItemCategoryId + '">';
                ul += '<li id ="default-custom-category' + SelectedItemCategoryId + '" class="list-group-item active category-li" >' + SelectedItemCategory + '<input class="float-right remove-custom-category btn btn-danger" type="button" value="x"></li ><li id="default-custom-' + SelectedItemNameId + '" class="list-group-item item-li">' + SelectedItemName + '<input class="float-right remove-custom-item btn btn-danger" type="button" value="x"></li></ul>';
                ul += '<div class="input-group mb-3  w-75 mr-auto ml-auto">';
                ul += '     <input type="text" class="form-control add-item-field" placeholder="Add item to category...">';
                ul += '     <div class="input-group-append">';
                ul += '         <button class="btn btn-outline-secondary add-item-button" type="button">Add</button>';
                ul += '     </div>';
                ul += '</div>';
                ul += '<br /><br /></div>';

                $('#CustomCategories').append(ul);
                AllCategoriesNamesNewList.push(SelectedItemCategory);
                RemoveCustomItemEventHandler();
                RemoveCustomCategoryEventHandler(AllCategoriesNamesNewList);

                var CategoryId = '#default-custom-category-' + SelectedItemCategoryId + ' .add-item-button';

                // Add Default Item Event Handler
                $(CategoryId).unbind().click(function (event) {
                    event.stopPropagation();
                    let newItemName = event.currentTarget.parentNode.parentNode.childNodes[0].nextSibling.value;

                    if (newItemName != "") {
                        let newItemLiElement = "<li id='default-custom-item-" + _NewDefaultItemButtonClick + "' class='list-group-item item-li'>" + newItemName + "<input class='float-right remove-custom-item btn btn-danger' type='button' value='x'></li>";

                        event.currentTarget.parentNode.parentNode.parentNode.children[0].insertAdjacentHTML("beforeend", newItemLiElement);
                        event.currentTarget.parentNode.parentNode.childNodes[0].nextSibling.value = "";

                        _NewDefaultItemButtonClick++;
                        RemoveCustomItemEventHandler();
                    }
                });

            } else {
                // If Category exists, only add Item.
                let li = '<li id="default-custom-' + SelectedItemNameId + '" class="list-group-item item-li">' + SelectedItemName + '<input class="float-right remove-custom-item btn btn-danger" type="button" value="x"></li>';
                let correspondingCategoryElement;

                // Add Default Item Event Handler
                $('#CustomCategories ul .category-li').each(function (i, obj) {
                    if (obj.innerText == SelectedItemCategory) {
                        correspondingCategoryElement = $('#CustomCategories ul .category-li').get(i);
                        return false;
                    }
                });

                correspondingCategoryElement.parentElement.querySelector('.category-li').parentElement.insertAdjacentHTML("beforeend", li);
            }
        }

        RemoveCustomItemEventHandler();

        if (AtLeastOneCategoryAndOneItemExists)
            AllowSave();
    });

    // Save List Event Handler
    $('#SaveListButton').click(function (event) {
        event.stopPropagation();
        let ListName = $('#NewListName').text();
        let categories = [];

        // Get New List information to send to controller
        $('#NewListContentDiv .category-li').each(function (i, obj) {
            if (obj.parentElement.getElementsByClassName('item-li').length != 0) {              
                categorieItems = [];
                categorieItems.push(obj.textContent);
                categories[i] = categorieItems;

                for (let j = 0; j < obj.parentElement.getElementsByClassName('item-li').length; j++) {
                    categories[i].push(obj.parentElement.getElementsByClassName('item-li')[j].textContent);
                }
            }
        });

        // Object containing information regarding New List to be sent to controller.
        let NewList = {
            Name: ListName,
            Categories: categories
        };

        // Send New List information to controller
        $.ajax({
            type: "POST",
            url: "SaveList",
            content: "application/json; charset=utf-8",
            dataType: "text",
            data: {
                NewListName: NewList.Name,
                NewListCategories: NewList.Categories
            },
            success: function () {
                location.href = '../List/MyLists';
            },
            error: function () {
                //alert(false);
            }
        });
    });

    // Record of already added categories
    let AllCategoriesNamesNewList = [];
};

// Removes Remove Custom Item Event element
function RemoveCustomItemEventHandler() {
    $('.remove-custom-item').unbind().click(function (event) {
        event.stopPropagation();
        event.currentTarget.parentElement.remove();
    });
}

// Removes Remove Custom Category element
function RemoveCustomCategoryEventHandler(existingCategoriesList) {
    $('.remove-custom-category').unbind().click(function (event) {
        event.stopPropagation();
        event.currentTarget.parentElement.parentElement.parentElement.remove();
        console.log(existingCategoriesList);
        existingCategoriesList.splice(existingCategoriesList.indexOf(event.currentTarget.parentElement.innerText), 1);
        console.log(existingCategoriesList);
    });
}

// Determines if Save New List is an available action depending on the content added
function AtLeastOneCategoryAndOneItemExists() {
    if (document.querySelector('#NewListContent .item-li') != null) {
        return true;
    } else {
        return false;
    }
}

// Shows Save New List Button
function AllowSave() {
    $('#SaveListDiv').css('display', 'block');
}
