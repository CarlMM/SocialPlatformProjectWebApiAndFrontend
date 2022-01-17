FEATURES + USERSTORIES

------------------------------------------

USER
--------------------------------
Feature Create User

As a person I want to create a User to post on the forum

Scenario: Create User

- Given that I am on the Register Me page
- And the User isnt registered on the forum already
- When the User fill in my peronal info
- Then a user is created

Scenario: Nickname is already taken.
- When I enter nickname
- And all the others details are correct
- And I submit the form
- Then I should be displayed a message nickname already in use.

-----------------------------------

Feature Create Post

As a User I want to create a new post on the forum

Scenario: Create Post (Confirm create post)

- Given that the User is logged in
- When the User press Create new post button
- And the User choose the category
- And the User types the text for the post
- And the User will press confirm post button
- Then the post will be created

Scenario: Cancel its Post (Cancel post)

- Given that the User is logged in
- When the User press Create new post button
- And the User choose the category
- And the User types the text for the post
- And then the User regrets its post
- And the User presses the Cancel Post button
- Then the post will not be created

-----------------------------------

Feature Edit Post

As a User and Creator of a post, I want to edit My post

Scenario: Edit Post

- Given that the User is logged in
- And the User is the creator of the post
- When the User/Creator presses the Edit button
- And the User/Creator will be able to Edit its post
- And The User/Creator will be able to save its edits
- Then the edits will be saved

Scenario: Cancel Edit Post

- Given that the User is logged in
- And the User is the creator of the post
- When the User/Creator presses the Edit button
- And the User/Creator will be able to Edit its post
- And The User/Creator will be able to cancel its edits
- Then the edits will be canceled

Scenario: None will be able to edit my post

- Given that the User is loggen in
- And the User is not the creator of the post
- Then the **Edit** button will not appear on the post

----------------------------------

Feature Delete Post

As a User and Creator of a post, I want to be able to delete my post from the forum

Scenario: The user wants to Delete Post (Confirm Delete)

- Given that the User is logged in
- And the User is the creator of the post
- When the User/Creator presses the delete button
- And a confirm message will pop up that will show Confirm button / Cancel Button
- And the User clicks confirm
- Then the post will be **deleted**

Scenario: The User doesnt want to delete its post (Cancel Delete)

- Given that the User is logged in
- And the User is the creator of the post
- When the User/Creator presses the delete button
- And a confirm message will pop up that will show Confirm button / Cancel Button
- And the user clicks Cancel Button
- Then the post will not be **deleted**

Scenario: None will be able to delete my post, other than admins

- Given that the User is loggen in
- And the User is not the creator of the post
- Then the **Delete** button will not appear on the post

----------------------------------

Feature Create Usergroups

Scenario: The user wants to create a grouppost

- Given that the User is logged in
- And the User clicks My Groups tab
- And the User clicks the Create Grouppost button
- And the User types the text for the post
- When the User will press confirm post button
- Then the post will be created
- And the User who created the group, becomes the administrator of that group

----------------------------------

Feature Delete/Edit Grouppost

Scenario: The user want to delete/edit its group post

**Look at row 51-107**

----------------------------------




Gruppadministratörer







Administrator
