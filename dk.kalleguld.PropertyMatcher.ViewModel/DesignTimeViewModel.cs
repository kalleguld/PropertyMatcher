using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.ViewModel
{
    public class ExampleDataViewModel : PropertyMatcherViewModel
    {
        public ExampleDataViewModel()
            : this(GetCtorData())
        {

        }

        private ExampleDataViewModel(CtorData cd)
            : base(cd.Inputs, cd.Outputs, cd.Connections)
        {

        }

        private static CtorData GetCtorData()
        {
            var result = new CtorData
            {
                Inputs = new Model.Table
                {
                    SystemId = "2",
                    SystemDocTypeId = "1",
                    SystemName = "Nav 2009",
                    SystemDescription = "Microsoft Dynamics Nav",
                    SystemVersion = "6.0",

                    SystemTableId = "2T1",
                    TableId = "T1",
                    TableUniqueId = "T00001",
                    TableName = "customer",
                    TableDescription = @"The Customer table is used to record information about all your customers.

The table contains information used by a range of facilities that can help minimize customer costs. For example, credit limit, balance amount and payment term facilities make it possible for the program to issue a credit and an overdue balance warning when you enter a sales order. Furthermore, reminder term and finance charge term facilities allow you to invoice interest and/or additional fees.

The Customer table contains a card for each customer, on which you enter basic information such as name, address, and discount possibilities. Each customer must also have an identifying number. When you enter the customer number elsewhere in the program (on a sales quote, for example), the program will automatically use information from the Customer table for that particular customer.

Before you can post to a customer, you must set up a connection from the customer card to a balance sheet account in the chart of accounts. You must set up a connection to an income statement account. You do this with posting groups, which you must enter in the Gen. Bus. Posting Group and Customer Posting Group fields. The posting groups are set up in the Gen. Business Posting Group and Customer Posting Group tables.

Once you have set up posting groups, you can enter them in the Gen. Bus. Posting Group and the Customer Posting Group fields on customer cards. Then when you post to a customer account, corresponding entries will automatically be created in the associated G/L accounts. The general ledger will therefore always agree with the customer's balance.

You can post to a customer in an unlimited number of currencies. The resulting customer ledger entries will show the currency of each entry.

The program can display the customers in two different windows:

The Customer Card window has a card for each customer, containing all the fields you have selected. You can therefore see many fields for each customer.

The Customer List window displays all the customers, with a line for each; therefore, fewer fields are displayed for each customer.",

                    Fields = new List<Model.Field>
                    {
                        new Model.Field
                    {
                        SystemTableId = "2T1",
                        Id = "T1F001",
                        Name = "timestamp",
                        Description = @"123",
                    },
                    new Model.Field
                    {
                        SystemTableId = "2T1",
                        Id = "T1F002",
                        Name = "No_",
                        Description = @"Here you can enter the customer number. You can use one of the following methods:

If you have set up a default customer number series, press Enter to have the program fill in this field with the next number in the series.

If you have set up more than one number series for customers, click the AssistButton in the field and select the series you want to use.The program will fill in the field with the next number in that series.

If you have not set up a number series for customers, or if the number series has a check mark in the Manual Nos.field, you can enter a number manually. You can enter a maximum of 20 characters, both numbers and letters. For example, you can use the customer's phone number as the customer number.

The number identifies the customer and is used when you post from a journal or set up quotes, orders, invoices and credit memos.

You cannot fill in the other fields in the Customer table until you have entered a number in the No. field.

",
                  },
                  new Model.Field
                {
                    SystemTableId = "2T1",
                    Id = "T1F003",
                    Name = "Name",
                    Description = @"Here you can enter the customer's name. You can enter a maximum of 30 characters, both numbers and letters.

The contents of the Name field are typically printed on invoices and similar documents. You should therefore enter the name as you want it to appear.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F004",
    Name = "Search Name",
    Description = @"Here you can enter a search name.

You can use the Search Name field to search for a customer when you cannot remember the customer number: Sunshine Bakery, for example.

When you enter something in the Name field and press Enter, the program automatically copies the contents to the Search Name field.

The contents of the Search Name field do not need to be the same as those of the Name field. You can enter a search name with a maximum of 30 characters, both numbers and letters.

Attention

If the search name was inserted automatically by the program, it will be changed each time you change the Name field. If you inserted the search name manually, it will not be changed automatically when the Name field is changed.

You can learn more about how to search in the program under Edit, Find on the menu bar.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F005",
    Name = "Name 2",
    Description = @"Here you can enter an additional part of the customer's name. You can enter a maximum of 30 characters, both numbers and letters.

The Name 2 field can be used, for example, if the customer has a long company name.

The contents of the Name 2 field are often used when you print something, so you should enter the name as you want it to appear.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F006",
    Name = "Address",
    Description = @"Here you can enter the customer's address. You can enter a maximum of 30 characters, both numbers and letters.

The contents of the Address field are often used when you print something, so you should enter the address as you want it to appear.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F007",
    Name = "Address 2",
    Description = @"Here you can enter another line of the customer's address. You can enter a maximum of 30 characters, both numbers and letters.

The contents of the Address 2 field are often used when you print something, so you should enter the address as you want it to appear.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F008",
    Name = "City",
    Description = @"This field contains the customer's city.

How the Post Code and City Fields Are Filled In

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F009",
    Name = "Contact",
    Description = @"Here you can enter the name of the person you regularly contact when you do business with this customer. You can enter a maximum of 30 characters, both numbers and letters.

When you enter a name in this field, a contact is created in the Relationship Management application area.

The contents of the Contact field are often used when you print something, so you should enter the name as you want it to appear.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F010",
    Name = "Phone No_",
    Description = @"Here you can enter the customer's telephone number. You can enter a maximum of 30 characters, both numbers and letters.

Use a standard format for the telephone number so that it will look uniform on printouts. For example:

123 456 7890 or 12 34 56 78

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F011",
    Name = "Telex No_",
    Description = @"Here you can enter the customer's telex number. You can enter a maximum of 20 characters, both numbers and letters.

Use a standard format for the telex number so that it will look uniform on printouts.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F012",
    Name = "Our Account No_",
    Description = @"Here you can enter your account number with the customer, if you have one. You can enter a maximum of 20 characters, both numbers and letters.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F013",
    Name = "Territory Code",
    Description = @"Here you can select a territory code for the customer. To see the territory codes in the Territories window, click the AssistButton in the field.

You can use this field to allocate customers to sales personnel. For example, select the code LND in the Territory Code field for all customers from London. Later, you will be able to set a filter so the program will display only the London customers. This will make it easier for salespeople assigned to London to get an overview of the customers there.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F014",
    Name = "Global Dimension 1 Code",
    Description = @"Here you can select a dimension value code. To see the dimension value codes you have set up for this dimension in the Dimension Values window, click the AssistButton in the field.

If you enter a dimension value code in this field, the program will use the corresponding dimension value as default each time you enter the account on an entry line. Default dimension values are only suggestions and you can change them on the entry line, for example in a journal.

Click here to learn more about dimensions.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F015",
    Name = "Global Dimension 2 Code",
    Description = @"Here you can select a dimension value code. To see the dimension value codes you have set up for this dimension in the Dimension Values window, click the AssistButton in the field.

If you enter a dimension value code in this field, the program will use the corresponding dimension value as default each time you enter the account on an entry line. Default dimension values are only suggestions and you can change them on the entry line, for example in a journal.

Click here to learn more about dimensions.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F016",
    Name = "Chain Name",
    Description = @"Here you can enter a code indicating the name of the chain or franchise group (if any) that the customer is part of. You can enter a maximum of 10 characters, both numbers and letters.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F017",
    Name = "Budgeted Amount",
    Description = @"Here you can enter a budget figure for the customer.

You cannot set up budgets for customers in the same way as you can for G/L accounts. Instead, you can enter one budget figure per customer in this field. This can represent, for example, the expected profit (LCY) or sales.

This field has no relationship to any budgets in the general ledger.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F018",
    Name = "Credit Limit (LCY)",
    Description = @"Here you can enter the maximum credit (in LCY) that can be extended to the customer.

The program uses this field to perform a test when you fill out journals, quotes, orders and invoices. It tests the sales header and individual sales lines to see whether the credit limit has been exceeded. You can post even though the credit limit has been exceeded. If the field is left blank, there will be no credit limit for this customer.

This field can also be used to print a list of customers who have exceeded their credit limit.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F019",
    Name = "Customer Posting Group",
    Description = @"Here you can select a code for the customer posting group to which the customer will belong. To see the customer posting group codes in the Customer Posting Groups window, click the AssistButton in the field.

The customer posting group specifies to which accounts in the general ledger the program will post for transactions involving this customer. This posting group specifies accounts for customer receivables, service charges, payment discount amounts, interest, additional fees and invoice rounding amounts.

Attention

The account for payment discounts is used only if there is no check mark in the field Adjust for Payment Disc. in the General Ledger Setup window.

Information on VAT % and the accounts (for VAT, sales, purchases, and so on) to which the program posts for transactions involving different customers, vendors, items and resources is specified in the VAT Posting Setup window.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F020",
    Name = "Currency Code",
    Description = @"Here you can select a default currency code for the customer. To see the currency codes in the Currencies window, click the AssistButton in the field.

This is the currency code that the program will suggest when you create sales documents or journal lines for the customer. You can change the currency code on sales documents and journal lines if the customer wishes to order in a different currency.

You can create customer invoices in any currency. If you invoice a customer in more than one currency, the program will show the currency of each entry in the resulting customer ledger entries.

You can change the customer's default currency as necessary.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F021",
    Name = "Customer Price Group",
    Description = @"This field contains the customer price group code. To see the price group codes in the Customer Price Group window, click the AssistButton in the field.

In the Sales Prices window, you can enter unit prices for an item that are different for different price groups. If the customer belongs to a particular price group, the program will use the appropriate unit price on quotes, orders and invoices instead of the item's standard unit price.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F022",
    Name = "Language Code",
    Description = @"Here you can select a code that determines the language to be used on any printouts for this customer. To see the language codes in the Languages window, click the AssistButton in the field.

In the Item Translations window you can set up foreign language descriptions of the items. If you have done this, the program will use the language code to insert the appropriate foreign text on printouts for the customer.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F023",
    Name = "Statistics Group",
    Description = @"Here you can enter a number that assigns this customer to a group for statistical purposes.

The Statistics Group field can be used in connection with the Customer - Summary Aging Simp. report. Once you have divided the customers into statistics groups (by putting all the bigger customers in Group 1 and all the smaller ones in Group 2) you can select to print out information about all the customers in Statistics Group 1, for example.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F024",
    Name = "Payment Terms Code",
    Description = @"Here you can select a code for the payment terms you will grant the customer. To see the payment terms codes in the Payment Terms window, click the AssistButton in the field.

A payment terms code stands for a formula that calculates the due date, payment discount date and payment discount amount. If you have entered the code on the customer card, the program will use the appropriate payment terms when you invoice the customer.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F025",
    Name = "Fin_ Charge Terms Code",
    Description = @"Here you can select a code that specifies how the program will compute finance charges for the customer. To see the finance charge terms codes in the Finance Charge Terms window, click the AssistButton in the field.

A finance charge terms code contains information about the interest calculation method, interest rate, and so on. Once you have entered the code on the customer card, the program will use the information to calculate the finance charges. The code also tells the program when to create finance charge memos and what to include on the memos.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F026",
    Name = "Salesperson Code",
    Description = @"Here you can select a code for the salesperson who normally handles this customer's account. To see the salesperson codes in the Salespeople/Purchasers window, click the AssistButton in the field.

When the code has been entered on the customer card, the program will use the appropriate salesperson as a default when you set up quotes, orders, invoices and credit memos. If you want to calculate commissions based on sales, it is important to enter salesperson codes correctly on invoices.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F027",
    Name = "Shipment Method Code",
    Description = @"Here you can select a code for the shipment method to be used when you ship to this customer. To see the shipment method codes in the Shipment Methods window, click the AssistButton in the field.

Once you have entered the code here, the program will use the shipment method you have selected as a default when you set up quotes, orders, invoices, credit memos, and so on for the customer.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F028",
    Name = "Shipping Agent Code",
    Description = @"Here you can select a code for the shipping agent for the customer. To see the shipping agent codes in the Shipping Agents window, click the AssistButton in the field.

After you assign a shipping agent code to a customer, the program will use this information to suggest a shipping agent code on sales documents that you create for the customer. However, you can change the shipping agent code on individual sales documents.

Later, you can use the shipping agent code to track packages that you ship to the customer.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F029",
    Name = "Place of Export",
    Description = @"Here you can enter the place of export that will normally be used for this customer. You can enter a maximum of 20 characters, both numbers and letters.

The place of export must be declared on customs documents.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F030",
    Name = "Invoice Disc_ Code",
    Description = @"This field displays the customer's invoice discount code. You can enter a maximum of 20 characters, both numbers and letters.

When you set up a new customer card, the number from the No. field is automatically copied to this field.

You then have two possibilities in this field:

If you want the customer to have an individual invoice discount, don't change the contents of this field, but set up terms for this invoice discount code in the Cust. Invoice Disc. window. To see the window, click the Sales button on the Customer Card window, and select Invoice Discount.

If you want several customers to have the same invoice discount, you can replace the default code with another one. This can be a code that has previously been set up, or it can be a new one. If you enter a new code, you must set up invoice discount terms for it in the Cust. Invoice Disc. window. After this, enter the new code in the Invoice Disc. Code field for each customer that you want to have the same invoice discount.

Use codes that are easy to remember and describe the invoice discount terms. For example:

20000 (the customer must buy at least LCY 20,000 worth of merchandise before the invoice discount is granted).

The invoice discount can be allowed/disallowed in the Price Groups window.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F031",
    Name = "Customer Disc_ Group",
    Description = @"This field contains the customer discount group code. To see the customer discount group codes in the Customer Discount Group table, click the AssistButton in the field.

The sales line discount depends on both the customer and the item. The size of the discount is determined by which customer discount group the customer belongs to and which item discount group the item belongs to.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F032",
    Name = "Country_Region Code",
    Description = @"Here you can select a country/region code for the customer. To see the country/region codes and address formats in the Countries/Regions window, click the AssistButton in the field.

This field is used for registering EU VAT and reporting INTRASTAT. You can also use the country/region code to sort customers in the customer list. This will let you see all the German customers, for example.

The program uses the country/region code to format the customer's address (post code, city, county, contact address) fields on printouts.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F033",
    Name = "Collection Method",
    Description = @"Here you can enter the method you normally use to collect payment from this customer (an automated bill payment service, for example). You can enter a maximum of 20 characters, both numbers and letters.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F034",
    Name = "Amount",
    Description = @"Here you can enter an amount that is billed periodically (a subscription price, for example).

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F035",
    Name = "Blocked",
    Description = @"You can prevent specific transactions from being processed for a customer by choosing a relevant level of blocking. The different options are as follows.

&lt;Blank&gt;
Any transaction is allowed for this customer.

Ship
New orders and new shipments cannot be created for this customer. Existing shipments not yet invoiced can be invoiced.

Invoice
New orders, new shipments and new invoices cannot be created for this customer. Existing shipments not yet invoiced cannot be invoiced.

All
No transaction is allowed for this customer, including payments.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F036",
    Name = "Invoice Copies",
    Description = @"Here you can enter the number of invoice copies that will always be printed out for this customer.

You can use this field for customers that are located abroad, for example. When you export, extra copies of the printouts are always needed for customs clearance.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F037",
    Name = "Last Statement No_",
    Description = @"This field displays the number of the last statement that was printed for this customer.

The number of the next statement will be one higher.

You can enter a different number, but you should be aware that this will interrupt the numerical sequence of the customer's statements.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F038",
    Name = "Print Statements",
    Description = @"Here you can choose whether to include this customer when you print statements.

When you want to print the Statement report, you use the filter field called Print Statements. This filters the printing, including only customers with a check mark in the Print Statements check box.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F039",
    Name = "Bill-to Customer No_",
    Description = @"Here you can enter a different customer's number. To see the customer numbers in the Customer table, click the AssistButton in the field.

It may be that when you ship to this customer, the invoice should be sent to a different customer. In this case, enter here the number of the customer who should be invoiced. The program will enter this customer number on quotes, orders, invoices and credit memos as a default, which you will be able to change.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F040",
    Name = "Priority",
    Description = @"Here you can enter a number that corresponds to the priority you give the customer.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F041",
    Name = "Payment Method Code",
    Description = @"Here you can enter a code for the method that the customer usually uses to submit payment (bank transfer or check, for example). You can enter a maximum of 10 characters, both numbers and letters. To see the payment methods in the Payment Methods window, click the AssistButton in the field.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F042",
    Name = "Last Date Modified",
    Description = @"This field shows when the customer card was last modified.

When you change information on the customer card, the program automatically updates the Last Date Modified field to show the current system date.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F043",
    Name = "Application Method",
    Description = @"Here you can choose how the program will apply payments for this customer.

To determine the application method, click the AssistButton in the field and select one of the two options:

Manual

Apply to Oldest

If you do not enter anything here, the application method will be Manual.

Your choice will have the following effect:

Manual means that the program will apply payments only if you specify a document.

Apply to Oldest means that if you do not specify a document for the payment to be applied to, the program will apply the payment to the oldest of the customer's open entries.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F044",
    Name = "Prices Including VAT",
    Description = @"Here you can specify whether you want the price in the Unit Price field on the sales lines and in sales reports to include VAT or not. To have the unit price include VAT, place a check mark in the check box.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F045",
    Name = "Location Code",
    Description = @"Here you can select a location code to be used for this customer. To see the location codes in the Locations window, click the AssistButton in the field.

If the field contains a location code, the program will always suggest items from a particular inventory location when you invoice the customer.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F046",
    Name = "Fax No_",
    Description = @"Here you can enter the customer's fax number. You can enter a maximum of 30 characters, both numbers and letters.

Use a standard format for the fax number so that it will look uniform on printouts. For example:

123 456 7890 or 12 34 56 78

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F047",
    Name = "Telex Answer Back",
    Description = @"Here you can enter the customer's telex answer back code. You can enter a maximum of 20 characters, both numbers and letters.

Use a standard format for the telex answer back code so that it will look uniform on printouts.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F048",
    Name = "VAT Registration No_",
    Description = @"Here you can enter the customer's VAT registration number. You can enter a maximum of 20 characters, both numbers and letters.

This field will be used when you do business with customers from EU countries/regions. The number will appear on invoices and will also be used for the VAT- VIES Declaration Tax Auth report.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F049",
    Name = "Combine Shipments",
    Description = @"Here you can specify whether several orders delivered to the customer can appear on the same invoice.

Your choice will be transferred as a default to the order header, where it can be changed. When invoicing you use the Combine Shipments batch job, which includes only orders that have a check mark in the Combine Shipments check box.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F050",
    Name = "Gen_ Bus_ Posting Group",
    Description = @"Here you can specify a general business posting group for the customer. To see the general business posting groups in the Gen. Business Posting Groups window, click the AssistButton in the field.

The code specifies to which general business posting group this particular customer belongs. The general business posting groups can be set up to group customers by geographical area (Domestic, EU countries/regions, Overseas, and so on) or type of business, or to distinguish between private entities and governmental agencies.

When you post transactions that involve this customer, the program uses this code in combination with a general product posting group code in the General Posting Setup window. The General Posting Setup specifies the accounts (for sales, discount amounts and so on) to which the program posts.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F051",
    Name = "Picture",
    Description = @"This field displays the picture that has been created for the customer.

The field is blank if no picture has been inserted.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F052",
    Name = "Post Code",
    Description = @"This field contains the customer's post code.

How the Post Code and City Fields Are Filled In

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F053",
    Name = "County",
    Description = @"Here you can enter the county of the customer. You can enter a maximum of 30 characters, both numbers and letters.

Use a standard format for county names, so they will look uniform on printouts.

The program uses the code in the Country/Region Code field to format the county name on printouts.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F054",
    Name = "E-Mail",
    Description = @"Here you can enter the customer's e-mail address. You can enter a maximum of 80 characters, both numbers and letters.

In the field is a button with a picture of an envelope on it. If your program is integrated with an e-mail system, you can click this button to open a window in which you can create and send a message. If you have entered an address in the E-mail field, the program automatically fills in this address in the To... field.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F055",
    Name = "Home Page",
    Description = @"Here you can enter the customer's home page address. You can enter a maximum of 80 characters, both numbers and letters.

In the field, there is a button with a picture of a globe on it. If your program is integrated with the Internet, you can click this button to access the customer's home page.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F056",
    Name = "Reminder Terms Code",
    Description = @"Here you can select a reminder terms code for the customer. To see the reminder terms codes in the Reminder Terms window, click the AssistButton in the field.

The reminder terms specify what information should be included on reminders and when the reminders should be created. Once you have assigned reminder terms to a customer, the program will automatically use this information when you use the Create Reminders batch job or the Suggest Reminder Lines batch job. To find the batch jobs, select Sales &amp; Receivables, Periodic Activities, Reminders and then click the Functions button.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F057",
    Name = "No_ Series",
    Description = @"This field contains the code for the number series that was used to assign the customer's number.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F058",
    Name = "Tax Area Code",
    Description = @"Here you can specify a tax area code for the customer. To see the available tax area codes, click the AssistButton in the field.

When you post transactions that involve this customer, the program uses this code in combination with a Tax Group code and the Tax Liable field to find the necessary information for calculating sales tax.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F059",
    Name = "Tax Liable",
    Description = @"Click to enter a check mark in this field if the customer is liable to sales tax.

When you post transactions that involve this customer, the program uses this code and a combination of the Tax Area Code and a Tax Group code to find the necessary information for calculating sales tax.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F060",
    Name = "VAT Bus_ Posting Group",
    Description = @"Here you can specify a VAT business posting group for the customer. To see the VAT business posting groups in the VAT Business Posting Groups window, click the AssistButton in the field.

The code specifies to which VAT business posting group this particular customer belongs.

When you post transactions that involve this customer, the program uses this code in combination with a VAT product posting group code to find the VAT %, the VAT calculation type and the VAT accounts in the VAT Posting Setup window.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F061",
    Name = "Reserve",
    Description = @"This field indicates whether the program will reserve items for this customer. The field contains one of the following options:

Never
You cannot reserve items for this customer unless the Reserve field on the item card contains Always. Then the program will automatically reserve the items.

Optional
The program does not reserve items automatically. You can reserve the items manually.

Always
The program always reserves items for this customer.

The program uses this field when processing sales documents for the customer.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F062",
    Name = "Block Payment Tolerance",
    Description = @"A check mark in this field indicates that the customer is not allowed payment tolerance.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F063",
    Name = "IC Partner Code",
    Description = @"This field contains the customer's IC partner code, if the customer is one of your intercompany partners.

If a partner code is assigned to the customer, then an intercompany transaction can be sent to the intercompany outbox when you create a sales document for the customer. Furthermore, when you post entries that have the customer's number on them, they will automatically be marked as intercompany entries.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F064",
    Name = "Prepayment %",
    Description = @"This field can contain a prepayment percent that applies to all orders for this customer, regardless of the items or services on the order lines. If you want to set up prepayments for individual items, you should leave this field blank and set up the prepayment percentages in the Sales Prepayment Percentages window instead.

Do not enter the percent sign. For example, if the Prepayment % is 7.5%, enter 7.5.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F065",
    Name = "Primary Contact No_",
    Description = @"This field contains the primary contact number for the customer.

When you enter a primary contact in this field, the name will be copied to the Contact field on the Contact Card.

To see the primary contact numbers in the Contact List window, click the AssistButton in the field.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F066",
    Name = "Responsibility Center",
    Description = @"Here you can enter the code for the responsibility center that will administer this customer by default.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F067",
    Name = "Shipping Advice",
    Description = @"This field contains advice about whether the customer will accept a partial shipment of the order.

You can enter one of two options about the way the customer wants to receive orders: Partial, for partial shipments, or Complete, for complete shipments.

The default value for this field is partial.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F068",
    Name = "Shipping Time",
    Description = @"This field contains the shipping time of the order. That is, the time it takes from when the order is shipped from the warehouse to when the order is delivered to the customer's address.

The program uses the Shipping Time field to calculate the planned delivery date and the promised delivery date on the sales order.

When you create a new order from this customer, the program automatically copies the contents of this field to the Shipping Time field on the header of the sales order.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F069",
    Name = "Shipping Agent Service Code",
    Description = @"In this field, you can select the code for the shipping agent service that you want to use for this customer. Click the AssistButton to see the list of shipping agent service codes that have been set up.

When you create a sales order for this customer, the program automatically copies the contents of this field to the Shipping Agent Service Code field on the sales order.

Note that you must first select a shipping agent code before you can select a shipping agent service code.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F070",
    Name = "Service Zone Code",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F071",
    Name = "Allow Line Disc_",
    Description = @"If this field contains a check mark, the program will calculate a line discount when the price is offered.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F072",
    Name = "Base Calendar Code",
    Description = @"In this field, you enter the code for the base calendar that you want to assign to your customer.

Click the AssistButton to see the Base Calendar List window. Select the relevant base calendar and click OK.

",
  },
  new Model.Field
{
    SystemTableId = "2T1",
    Id = "T1F073",
    Name = "Copy Sell-to Addr_ to Qte From",
    Description = @"This is an option field which contains the type of contact, either company or person. The program preselects the Company option as a default, but you can change it by clicking the AssistButton to the right of the field and selecting the Person option.

When you create a new Sales Quote for the customer in the Sales and Receivables area, the program will retrieve the information about the customer and fill in the relevant fields from the corresponding customer card.

If you have selected the Person option, when you create a new sales quote and change the contact number in the Sell-to Contact No. field to the contact number of a person, the system will retrieve the information about the selected contact and fill in the relevant Sell-to Address, Sell-to Address 2, and Sell-to Post Code/City fields from the corresponding contact card.

",
  },
                    }
                },
                Outputs = new Model.Table
                {

                    SystemId = "3",
                    SystemDocTypeId = "1",
                    SystemName = "C5 2012",
                    SystemDescription = "Microsoft Dynamics C5",
                    SystemVersion = "6.0",

                    SystemTableId = "3T1",
                    TableId = "T1",
                    TableUniqueId = "T00001",
                    TableName = "CUSTTABLE",

                    Fields = new List<Model.Field>
                    {
                        new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F001",
    Name = "DATASET",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F002",
    Name = "ROWNUMBER",
    IsMandatory = false,
    Sample = "26576",
    Attribute = "SYSTEM, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F003",
    Name = "LASTCHANGED",
    IsMandatory = false,
    Sample = "28-10-2009 00:00:00",
    Attribute = "SYSTEM, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F004",
    Name = "DEL_USERLOCK",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F005",
    Name = "ACCOUNT",
    Description = "Customer's a/c",
    IsMandatory = false,
    Sample = "  75503110",
    Attribute = "CREATE, STORE, RIGHT",
    Reference = "CustTable.Account",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F006",
    Name = "NAME",
    Description = "Customer name",
    IsMandatory = false,
    Sample = "Kombi Borde ApS",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F007",
    Name = "ADDRESS1",
    Description = "Customer address",
    IsMandatory = false,
    Sample = "Nordskovvej 1",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F008",
    Name = "ADDRESS2",
    Description = "Customer address",
    IsMandatory = false,
    Sample = "Hans Klemm Strasse 18",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F009",
    Name = "ZIPCITY",
    Description = "Customer's zip code/city",
    IsMandatory = false,
    Sample = "6000  Kolding",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F010",
    Name = "COUNTRY",
    Description = "Customer country code",
    IsMandatory = false,
    Sample = "Danmark",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "Country.Country",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F011",
    Name = "ATTENTION",
    Description = "Customer contact",
    IsMandatory = false,
    Sample = "Pernille Halberg",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F012",
    Name = "PHONE",
    Description = "Customer phone number",
    IsMandatory = false,
    Sample = "75505028",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F013",
    Name = "FAX",
    Description = "Customer's fax no.",
    IsMandatory = false,
    Sample = "75508876",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F014",
    Name = "INVOICEACCOUNT",
    Description = "Other customer, if any, to address the invoice to",
    IsMandatory = false,
    Sample = "  79797979",
    Attribute = "CREATE, UPDATE, STORE, RIGHT",
    Reference = "CustTable.Account",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F015",
    Name = "GROUP_",
    Description = "Customer group to which the customer is related",
    IsMandatory = false,
    Sample = "Indland",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "CustGroup.Group",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F016",
    Name = "FIXEDDISCPCT",
    Description = "Customer's fixed discount in %",
    IsMandatory = false,
    Sample = "0,000000000000",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F017",
    Name = "APPROVED",
    Description = "The entries are approved by default",
    IsMandatory = false,
    Sample = "Enum: NoYes, Like: 1",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F018",
    Name = "PRICEGROUP",
    Description = "Determines price and VAT calculation on sales orders",
    IsMandatory = false,
    Sample = "Grossist",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "InvenPriceGroup.Group",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F019",
    Name = "DISCGROUP",
    Description = "Determines customer's discount group",
    IsMandatory = false,
    Sample = "Normal",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "CustDiscGroup.DiscGroup",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F020",
    Name = "CASHDISC",
    Description = "Cash discount terms for the customer",
    IsMandatory = false,
    Sample = "Deb7dgNet",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "CashDisc.CashDisc",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F021",
    Name = "IMAGEFILE",
    Description = "Image file name",
    IsMandatory = false,
    Sample = " ",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F022",
    Name = "CURRENCY",
    Description = "Default currency in gen. journals and orders. (Blank: Balance in %1)",
    IsMandatory = false,
    Sample = "DKK",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "Currency.Currency",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F023",
    Name = "LANGUAGE_",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F024",
    Name = "PAYMENT",
    Description = "Payment terms for the customer",
    IsMandatory = false,
    Sample = "Net30",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "Payment.Payment",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F025",
    Name = "DELIVERY",
    Description = "Delivery mode code",
    IsMandatory = false,
    Sample = "ab",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "Delivery.Delivery",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F026",
    Name = "BLOCKED",
    Description = "Is the customer locked?",
    IsMandatory = false,
    Sample = "Enum: Blocked, Like: 0",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F027",
    Name = "SALESREP",
    Description = "Employee related to the customer in connection with sales",
    IsMandatory = false,
    Sample = "IRJ",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "Employee.Employee",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F028",
    Name = "VAT",
    Description = "Customer's VAT code when invoicing",
    IsMandatory = false,
    Sample = "Salg",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "Vat.Vat",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F029",
    Name = "DEL_STATTYPE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F030",
    Name = "GIRONUMBER",
    Description = "Customer's giro number",
    IsMandatory = false,
    Sample = " ",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F031",
    Name = "VATNUMBER",
    Description = "Customer's VAT number",
    IsMandatory = false,
    Sample = "138546971",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F032",
    Name = "INTEREST",
    Description = "Customer's interest terms and percentage",
    IsMandatory = false,
    Sample = "1",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "Interest.Interest",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F033",
    Name = "DEPARTMENT",
    Description = "Customer's department",
    IsMandatory = false,
    Sample = " ",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "Department.Department",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F034",
    Name = "REMINDERCODE",
    Description = "Max. no. of reminders to be sent to the customer",
    IsMandatory = false,
    Sample = "Enum: ReminderCode, Like: 5",
    Attribute = "UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F035",
    Name = "ONETIMECUSTOMER",
    Description = "Is the customer a one-off customer?",
    IsMandatory = false,
    Sample = "Enum: NoYes, Like: 0",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F036",
    Name = "INVENTORY",
    Description = "Inventory management when creating orders",
    IsMandatory = false,
    Sample = "Enum: SalesInvtStatus, Like: 0",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F037",
    Name = "EDIADDRESS",
    Description = "EDI location number for electronic data exchange with the customer",
    IsMandatory = false,
    Sample = " ",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "CQL_CHECK.#set.EDIAddress.=.StrKeep(EDIAddress,\"0123456789\").#",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F038",
    Name = "BALANCE",
    Description = "Customer's current balance",
    IsMandatory = false,
    Sample = "0,000000000000",
    Attribute = "STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F039",
    Name = "BALANCE30",
    Description = "Balance for the account up to 30 days",
    IsMandatory = false,
    Sample = "0,000000000000",
    Attribute = "STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F040",
    Name = "BALANCE60",
    Description = "Balance for the account 31-60 days old",
    IsMandatory = false,
    Sample = "0,000000000000",
    Attribute = "STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F041",
    Name = "BALANCE90",
    Description = "Balance for the account 61-90 days old",
    IsMandatory = false,
    Sample = "0,000000000000",
    Attribute = "STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F042",
    Name = "BALANCE120",
    Description = "Balance for the account 91-120 days old",
    IsMandatory = false,
    Sample = "0,000000000000",
    Attribute = "STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F043",
    Name = "BALANCE120PLUS",
    Description = "Balance for the account more than 120 days old",
    IsMandatory = false,
    Sample = "0,000000000000",
    Attribute = "STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F044",
    Name = "AMOUNTDUE",
    Description = "Due balance for the customer",
    IsMandatory = false,
    Sample = "0,000000000000",
    Attribute = "STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F045",
    Name = "CALCULATIONDATE",
    Description = "Date of the last calculation of due balance",
    IsMandatory = false,
    Sample = "28-10-2009 00:00:00",
    Attribute = "STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F046",
    Name = "BALANCEMAX",
    Description = "Max. credit granted to the customer in default currency. (0= No maximum)",
    IsMandatory = false,
    Sample = "0,000000000000",
    Attribute = "CREATE, UPDATE, STORE, NATIONAL",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F047",
    Name = "BALANCEMST",
    Description = "Balance for the customer in %3",
    IsMandatory = false,
    Sample = "0,000000000000",
    Attribute = "STORE, NATIONAL",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F048",
    Name = "SEARCHNAME",
    Description = "Search name for the customer",
    IsMandatory = false,
    Sample = "KOMBI",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F049",
    Name = "DEL_TRANSPORT",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F050",
    Name = "CASHPAYMENT",
    Description = "Should the customer be invoiced as cash payment?",
    IsMandatory = false,
    Sample = "Enum: NoYes, Like: 0",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F051",
    Name = "PAYMENTMODE",
    Description = "Code of the payment method concerning OCR line",
    IsMandatory = false,
    Sample = " ",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F052",
    Name = "SALESGROUP",
    Description = "Order group to which the customer is related",
    IsMandatory = false,
    Sample = " ",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "SalesGroup.Group",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F053",
    Name = "PROJGROUP",
    Description = "Project group to which the customer is related",
    IsMandatory = false,
    Sample = "Jensen",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "ProjGroup.Group",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F054",
    Name = "TRADECODE",
    Description = "The current transaction type",
    IsMandatory = false,
    Sample = " ",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "TradeCode.TradeCode",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F055",
    Name = "TRANSPORTCODE",
    Description = "The current transport code",
    IsMandatory = false,
    Sample = " ",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "TransportCode.TransportCode",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F056",
    Name = "EMAIL",
    Description = "E-mail address",
    IsMandatory = false,
    Sample = " ",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F057",
    Name = "URL",
    Description = "Internet homepage",
    IsMandatory = false,
    Sample = " ",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F058",
    Name = "CELLPHONE",
    Description = "Customer's cell phone",
    IsMandatory = false,
    Sample = " ",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F059",
    Name = "KRAKNUMBER",
    Description = "Company's number at Krak",
    IsMandatory = false,
    Sample = " ",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F060",
    Name = "CENTRE",
    Description = "Customer's cost centre",
    IsMandatory = false,
    Sample = " ",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "Centre.Centre",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F061",
    Name = "PURPOSE",
    Description = "Customer's purpose",
    IsMandatory = false,
    Sample = " ",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "Purpose.Purpose",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F062",
    Name = "EANNUMBER",
    Description = "Customer's EAN number",
    IsMandatory = false,
    Sample = " ",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F063",
    Name = "DIMACCOUNTCODE",
    Description = "Customer's a/c dimension",
    IsMandatory = false,
    Sample = " ",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F064",
    Name = "XMLINVOICE",
    Description = "Create OIOXML file",
    IsMandatory = false,
    Sample = "Enum: NoYes, Like: 0",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F065",
    Name = "LASTINVOICEDATE",
    Description = "Date of the latest invoice",
    IsMandatory = false,
    Sample = "01-01-1900 00:00:00",
    Attribute = "STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F066",
    Name = "LASTPAYMENTDATE",
    Description = "Date of the latest payment",
    IsMandatory = false,
    Sample = "01-01-1900 00:00:00",
    Attribute = "STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F067",
    Name = "LASTREMINDERDATE",
    Description = "Date of the latest reminder",
    IsMandatory = false,
    Sample = "01-01-1900 00:00:00",
    Attribute = "STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F068",
    Name = "LASTINTERESTDATE",
    Description = "Date of the latest interest accrual",
    IsMandatory = false,
    Sample = "01-01-1900 00:00:00",
    Attribute = "STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F069",
    Name = "LASTINVOICENUMBER",
    Description = "Latest invoice number",
    IsMandatory = false,
    Sample = "                  63",
    Attribute = "STORE, RIGHT",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F070",
    Name = "XMLIMPORT",
    Description = "Import from XML ",
    IsMandatory = false,
    Sample = "Enum: NoYes, Like: 0",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F071",
    Name = "VATGROUP",
    Description = "VAT group",
    IsMandatory = false,
    Sample = " ",
    Attribute = "CREATE, UPDATE, STORE",
    Reference = "VatGroup.Group",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F072",
    Name = "STDACCOUNT",
    Description = "Specify if the customer is used as template customer",
    IsMandatory = false,
    Sample = "Enum: NoYes, Like: 0",
    Attribute = "CREATE, UPDATE, STORE",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F073",
    Name = "ePluginOriginReference",
  },
  new Model.Field
  {
    SystemTableId = "3T1",
    Id = "T1F074",
    Name = "ePluginOriginModule",
  },

                    },
                }
            };

            result.Connections = new List<Model.Connection>
            {
                new Model.Connection(result.Inputs.Fields[0], result.Outputs.Fields[0], Model.Connection.Creator.Auto),
                new Model.Connection(result.Inputs.Fields[1], result.Outputs.Fields[1], Model.Connection.Creator.Auto),
                new Model.Connection(result.Inputs.Fields[1], result.Outputs.Fields[2], Model.Connection.Creator.Auto),
                new Model.Connection(result.Inputs.Fields[1], result.Outputs.Fields[3], Model.Connection.Creator.Auto),
                new Model.Connection(result.Inputs.Fields[2], result.Outputs.Fields[4], Model.Connection.Creator.Auto),
            };

            return result;
        }

        private class CtorData
        {
            internal Model.Table Inputs;
            internal Model.Table Outputs;
            internal IEnumerable<Model.Connection> Connections;
        }
    }
}
