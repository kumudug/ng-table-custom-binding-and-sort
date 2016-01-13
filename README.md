# ng-table-custom-binding-and-sort
Example POC done before using ng-table in a large scale project

##  The problem

I was asked to solve some sorting problems of an enterprise level angular application which had a grid view displaying a large number or data. The current implementation was a hack job using jquery and I decided to rewrite it using angular and ng-table.

## The reason

Before the implementation I had to make sure I can do everything I need to do using ng-table

## Requirements

1. Be able to show a large amount of data with paging
2. Handle the paging using front end and the back end [requrest page from front end and serve the page data from the back end]
3. Handle the paging from front end only [request all the data from the back end and handle the sorting in the front end]
4. Add/Edit/Delete records inline in ng-table
sfd
