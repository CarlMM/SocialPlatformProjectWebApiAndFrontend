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

-----------------------------------

Feature Create Post

As a User I want to create a new post on the forum

Scenario: Create Post

- Given that the User is logged in
- When the User press Create new post button
- And the User choose the category
- And the User types the text for the post
- And the User will press finish post button
- Then the post will be created

-----------------------------------

Feature Edit Post

As a User and Creator of a post, I want to edit My post

Scenario: Edit Post

- Given that the User is logged in
- And the User is the creator of the post
- When the User/Creator presses the Edit button
- And the User/Creator will be able to Edit its post
- And 

----------------------------------

Feature Delete Post

As a User and Creator of a post, I want to be able to delete my post from the forum

Scenario: Delete Post

- Given that the User is logged in
- And the User is the creator of the post
- When the User/Creator presses the delete button
- Then the post will be deleted

------------------------------------

Feature Redigera Användare

Feature Skapa AnvändareGrupp


Gruppadministratörer







Administratör
