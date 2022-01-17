# FEATURES + USERSTORIES

------------------------------------------

## USER

Feature: Create User

As a person I want to create a User to post on the forum

Scenario: Create User

- Given that I am on the Register Me page
- And the User isnt registered on the forum already
- When the User fill in my peronal info
- Then a user is created

Scenario: Nickname/email is already taken.

- Given that I enter a nickname/email
- When I enter nickname/email
- And all the others details are correct
- And I submit the form
- Then I should be displayed a message nickname already in use.

-----------------------------------

Feature: Failed login

As a User, I want to get an error message when my log in failed

Scenario: Wrong input emailaddress/nickname

- Given I entered wrong email/nickname
- When I enter emailadress
- And all the others details are correct
- And I submit the form
- Then I should be displayed a message wrong email/nickname format.

-----------------------------------

Feature: Create Post

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

Feature: Edit Post

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

-----------------------------------

Feature: Delete Post

As a User and Creator of a post, I want to be able to delete my post from the forum

Scenario: The user wants to Delete Post (Confirm Delete)

- Given that the User is logged in
- And the User is the creator of the post
- When the User/Creator presses the delete button
- And a confirm message will pop up that will show Confirm button / Cancel Button
- And the User clicks confirm
- Then the post will be **Deleted**

Scenario: The User doesnt want to delete its post (Cancel Delete)

- Given that the User is logged in
- And the User is the creator of the post
- When the User/Creator presses the delete button
- And a confirm message will pop up that will show Confirm button / Cancel Button
- And the user clicks Cancel Button
- Then the post will not be **Deleted**

Scenario: None will be able to delete my post, other than admins

- Given that the User is loggen in
- And the User is not the creator of the post
- Then the **Delete** button will not appear on the post

-----------------------------------

Feature: Create Usergroups

Scenario: The user wants to create a grouppost

- Given that the User is logged in
- And the User clicks My Groups tab
- And the User clicks the Create Grouppost button
- And the User types the text for the post
- When the User will press confirm post button
- Then the post will be created
- And the User who created the group, becomes the administrator of that group

-----------------------------------

Feature: Delete/Edit Grouppost

Scenario: The user want to delete/edit its group post

**Look at FEATURE DELETE POST and FEATURE EDIT POST UP ABOVE**

-----------------------------------


## Group Administrator


**GA = Group Administrator**

Feature: Invite Users to group

Scenario: As GA, I want to search for Users to invite for the group

- Given that the User is a GA
- And the GA presses Add User button
- When the add user button is pressed, a list of all users will be shown
- Then a list of all users will be shown


Scenario: As GA, I want to add a User from a list to my group

- Given that the GA have a list of Users
- And the GA finds the User that the GA wants to invite
- When the GA presses the add User button next to the User listname
- Then the User will be added to the group

-----------------------------------

Feature: Remove Users from group

Scenario: As GA, I want to remove a User from my group (**Confirm**)

- Given that the GA have a list of Users in the group
- And the GA wants to remove a specific User
- And there is a Remove Button available next to the Users name
- When the GA presses the Remove button
- Then a Confirm Message will show with **Confirm**/Cancel removal
- And the User will be removed from the group

Scenario: As GA, I regret to remove a User from my group (**Cancel**)

- Given that the GA have a list of Users in the group
- And the GA wants to remove a specific User
- And there is a Remove Button available next to the Users name
- When the GA presses the Remove button
- Then a Confirm Message will show with Confirm/**Cancel** removal
- And the User will not be removed from the group

-----------------------------------

Feature: Delete a group

Scenario: As GA, I want to Delete a group of mine (**Confirmed**)

- Given that the GA has a group
- And the GA wants to remove a Group
- And there is a Delete Button next to a group
- When the GA presses Delete group
- Then a Confirm Message will show with **Confirm**/Cancel Delete
- And the group will be deleted


Scenario: As GA, I regret to delete a group of mine (**Cancel**)

- Given that the GA has a group
- And the GA wants to remove a Group
- And there is a Delete Button next to a group
- When the GA presses Delete group
- Then a Confirm Message will show with Confirm/**Cancel** Delete
- And the GA presses the Cancel, and the group will not be deleted

-----------------------------------

Feature: Delete post/comment from my group

Scenario: As GA, I want to Delete a post in a group of mine (**Confirmed**)

- Given that the GA has a group
- And the GA wants to remove a post in a group of mine
- And there is a Delete Button next to a post
- When the GA presses Delete post
- Then a Confirm Message will show with **Confirm**/Cancel Delete
- And the post will be deleted


Scenario: As GA, I regret to delete a post in a group of mine (**Cancel**)

- Given that the GA has a group
- And the GA wants to remove a post in a group of mine
- And there is a Delete Button next to a post
- When the GA presses Delete post
- Then a Confirm Message will show with Confirm/**Cancel** Delete
- And the post will be deleted

-----------------------------------

## Administrator

**MAIN ADMIN = MA**

FEATURE: Be able to log in as a MA

Scenario: MA wants to log in

- Given that the User is a MA
- And the User is on the Login page
- When the MA fills in its info (Credentiales)
- And then presses the log in button
- Then the MA will be redirected to the Admin page

-----------------------------------

Feature: Be able to see a list of all Users

Scenario: MA wants to be able to see a list of all users

- Given that the User is a MA
- And the MA is on the Adminpage
- And there is a All Users tab
- When the MA presses the All Users tab
- Then a list of all Users will be shown

-----------------------------------

Feature: Be able to see a list of all Groups

Scenario: MA wants to be able to see a list of all groups

- Given that the User is a MA
- And the MA is on the Adminpage
- And there is a All Groups tab
- When the MA presses the All Groups tab
- Then a list of all Groups will be shown

-----------------------------------

Feature: Be able to see a list of all Posts

Scenario: MA wants to be able to see a list of all posts

- Given that the User is a MA
- And the MA is on the Adminpage
- And there is a All Posts tab
- When the MA presses the All Posts tab
- Then a list of all Posts will be shown

-----------------------------------

Feature: Delete/block a User from the forum

Scenario: An user has been a naughty boy, MA wants to Delete the user (**Confirm**)

- Given there is a list of Users
- And there is a Delete User Button next to the Users name
- When the MA presses the Delete Button
- Then a Confirm message will be shown **Confirm**/Cancel button Delete


Scenario: An user has been a naughty boy, MA wants to remove the user (**Cancel**)

- Given there is a list of Users
- And there is a Delete User Button next to the Users name
- When the MA presses the Delete Button
- Then a Confirm message will be shown Confirm/**Cancel** button Delete

-----------------------------------

Feature: Remove content(Groups/Posts)

Scenario: As MA, I want to remove a post (**Confirm**)

- Given that the User is a MA
- And there is a Post that MA wants to remove
- And there is a Delete Button next to a post
- When MA presses the Delete button a **Confirm**/Cancel message will be shown
- And then MA presses the **Confirm** button
- Then the post will be removed

Scenario: As MA, I regret to remove a post (**Cancel**)

- Given that the User is a MA
- And there is a Post that MA wants to remove
- And there is a Delete Button next to a post
- When MA presses the Delete button a Confirm/**Cancel** message will be shown
- And then MA presses the **Cancel** button
- Then the post will not be removed

Scenario: As MA, I want to remove a group (**Confirm**)

- Given that the User is a MA
- And there is a Group that MA wants to remove
- And there is a Delete Button next to a Group
- When MA presses the Delete button a **Confirm**/Cancel message will be shown
- And then MA presses the **Confirm** button
- Then the post will be removed

Scenario: As MA, I regret to remove a group (**Cancel**)

- Given that the User is a MA
- And there is a Group that MA wants to remove
- And there is a Delete Button next to a Group
- When MA presses the Delete button a Confirm/**Cancel** message will be shown
- And then MA presses the **Cancel** button
- Then the post will be removed









