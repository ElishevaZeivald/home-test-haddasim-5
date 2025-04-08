****part A:****
(Written in c#)

**sectionA:**

i made the first funstion to split the 'log' file to small files 
after i wrote a function to found the errors-code where I called the function that count errors in file by turn it into a dictionary 
and what is returned from that function i sorted the dictionary by the frequency of errors 
And finally I returned the most common errors.

**sectionB:**

**1:**

Initially, I was asked to perform health checks on the attached file.And I did a number of functions:the first one cheks if all the dates at the attached file are valid
by copy all the file lines into array -
if not i removed the line with the invalid date at the array,
Also i made check function to remove lines at the file that contain in-valid value -the function copy all the right line from the attached file to a new file who doesn't contain in=valid value
I also created a function that will make sure there are no duplicates in the file.

**2:**

I needed to create a function that would calculate the average of values ​​by hour on each date. 
I did this by building two matrices of size 24 hours by 30 days (a matrix that will contain the average values ​​for the entire month) - one contains the average sum by hours 
and the second counts how many times we made an addition at a particular hour in the first matrix.
In addition, I created a dictionary that will contain the average values ​​at the end for output,
I copied all the lines of the file into an array on which I executed a loop that enters the data into the matrices,
Finally, I go through the matrices and for each column I perform an average calculation using a matrix of counts and enter the data into the dictionary.
Then I went through the dictionary and printed the average by hour and date of the month.

Then I created an array that inserts all the files that were created into it, and at each location in the array (each file) I call the previous function that calculates an average
And finally I merged everything and inserted it into a new file.
Then I created an array that inserts all the files that were created into it,
and at each location in the array (each file) I call the previous function that calculates an average
And finally I merged everything and inserted it into a new file.

**3:**

I wrote the request for the following section in a comment in the code.

**4:**

I installed the Parquet.Net folder


**part B:**
(Written in MySQL Workbench )

I uploaded SQL scripts, in which I performed the table creation requirements and then executed queries on the tables as requested.
-a query that builds a new table that will contain all the family members of each person in the people table,
And a query that goes through the people table and if someone has a spouse and he exists in the people table it checks if the spouse is also entered in his spouse record and if not it adds it.

**part C:**

Attached is a WORD file that answers the questions in this section.

**part D**
(Written in c#)

I wrote a server for the requested interface.
I developed a project on the 3-tier model, which has models for supplier, orders, user - to enforce whether he is an administrator or supplier, product and list of products in the order.
I am implementing a MAPPER in it that will convert between the layers
