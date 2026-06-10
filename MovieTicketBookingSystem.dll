# MOVIE TICKET BOOKING SYSTEM

CURRENT FLOW (EXISTING PROJECT)

Application Starts

↓

Hardcoded Movie Created

↓

Hardcoded Theater Created

↓

Hardcoded Show Created

↓

Hardcoded Booking Created

↓

Payment Processed

↓

Notification Sent

↓

Booking Saved

↓

Display Booking History

↓

Application Closed

⸻

LIMITATIONS

No User Registration

No Login

No Customer Data

No Multiple Movies

No Theater Selection

No Show Selection

No Seat Selection

No Seat Availability Validation

No Dynamic Ticket Price Calculation

No Wallet Management

No Payment Balance Validation

No Payment Method Switching

No Ticket Generation

No Persistent Customer Records

⸻

TARGET ASSIGNMENT FLOW

Application Starts

↓

Register

or

Login

↓

Display Main Menu

↓

Select Movie

↓

Select Theater

↓

Select Show Time

↓

Select Seat Type

↓

Select Seats

↓

Validate Availability

↓

Calculate Amount

↓

Select Payment Method

↓

Validate Balance

↓

Deduct Balance

↓

Generate Ticket

↓

Save Records

↓

Display Ticket

↓

Return To Menu

⸻

REGISTRATION FLOW

Application Starts

↓

1. Register
2. Login

⸻

REGISTER

Enter Name

Enter Email

Enter Phone

Create UPI Balance

Create Card Balance

Save Customer

⸻

Example

Customer Id : 1

Name : Neelapu

UPI Balance : 5000

Card Balance : 10000

⸻

LOGIN FLOW

Display Customers

↓

Select Customer

↓

Load Customer Data

↓

Display Main Menu

⸻

MAIN MENU

========================================

MOVIE TICKET BOOKING SYSTEM

========================================

1. Book Ticket
2. View My Tickets
3. View Wallet Balances
4. Add Balance
5. Logout
6. Exit

========================================

⸻

BOOK TICKET FLOW

STEP 1

Display Movies

⸻

1. OG
2. Pushpa 2
3. Salaar
4. Devara

⸻

Select Movie

↓

Movie Loaded

⸻

STEP 2

Display Available Theaters

⸻

PVR Hyderabad

INOX Vijayawada

AMB Hyderabad

Asian Uppal

⸻

Select Theater

↓

Theater Loaded

⸻

STEP 3

Display Available Show Timings

⸻

10:00 AM

2:00 PM

6:00 PM

10:00 PM

⸻

Select Show

↓

Show Loaded

⸻

STEP 4

Display Seat Categories

⸻

1. Recliner
2. Exclusive
3. Classic

⸻

Select Category

⸻

SEAT STRUCTURE

Recliner

R1
R2
R3
R4
R5
R6
R7
R8
R9
R10

⸻

Exclusive

E1
E2
E3
E4
E5
E6
E7
E8
E9
E10

⸻

Classic

C1
C2
C3
C4
C5
C6
C7
C8
C9
C10

⸻

STEP 5

Display Seat Status

Example

R1 Available

R2 Booked

R3 Available

R4 Available

⸻

Select Seat Numbers

Example

R1

R3

R4

⸻

VALIDATION

If Seat Available

Allow Booking

⸻

If Seat Already Booked

Throw Exception

⸻

Example

Seat R2 Already Booked

Select Another Seat

⸻

Or

Choose Available Seats

⸻

STEP 6

CALCULATE PRICE

⸻

Seat Prices

Recliner = 400

Exclusive = 250

Classic = 150

⸻

Example

Selected

R1

R3

R4

⸻

3 Seats

⸻

Amount

400 × 3

= 1200

⸻

Display

Total Amount : 1200

⸻

STEP 7

SELECT PAYMENT MODE

⸻

1. UPI
2. Card

⸻

Display Available Balances

⸻

UPI Balance : 5000

Card Balance : 10000

⸻

STEP 8

PAYMENT VALIDATION

⸻

Example

Amount = 1200

UPI Balance = 5000

⸻

Payment Allowed

⸻

Balance Deducted

5000 - 1200

= 3800

⸻

UPDATED BALANCE

3800

⸻

INSUFFICIENT BALANCE FLOW

Amount = 1200

UPI Balance = 1000

⸻

Output

Insufficient UPI Balance

⸻

Options

1. Choose Card
2. Add Balance
3. Cancel Booking

⸻

STEP 9

GENERATE TICKET

Generate Unique Ticket

⸻

Example

Ticket Id

TKT-20250909-1001

⸻

Ticket Contains

Customer Name

Movie Name

Theater

Show Time

Seats

Seat Category

Amount

Payment Mode

Transaction Time

⸻

STEP 10

SAVE RECORDS

Save Booking

Save Customer Balance

Save Seat Status

Save Transaction

⸻

FILES REQUIRED

customers.txt

movies.txt

theaters.txt

shows.txt

seats.txt

transactions.txt

tickets.txt

⸻

STEP 11

DISPLAY TICKET

⸻

================================

MOVIE TICKET

================================

Ticket Id

TKT-20250909-1001

Customer

Neelapu

Movie

OG

Theater

PVR Hyderabad

Show

6:00 PM

Seats

R1,R3,R4

Amount

1200

Payment

UPI

================================

⸻

STEP 12

RETURN TO MENU

1. Book Another Ticket
2. View My Tickets
3. Logout
4. Exit

⸻

NEW MODELS REQUIRED

Customer

Wallet

Seat

Ticket

Transaction

⸻

NEW SERVICES REQUIRED

CustomerService

MovieService

TheaterService

ShowService

SeatService

PaymentService

WalletService

TicketService

TransactionService

⸻

NEW VALIDATIONS REQUIRED

Customer Exists

Movie Exists

Theater Exists

Show Exists

Seat Exists

Seat Available

Balance Available

Payment Success

⸻

EXCEPTIONS REQUIRED

CustomerNotFoundException

MovieNotFoundException

ShowNotFoundException

SeatAlreadyBookedException

InsufficientBalanceException

PaymentFailedException

⸻

PHASE 1 UPGRADE RESULT

From

Simple Demo Application

↓

To

Complete Console-Based Movie Ticket Booking System

With

Registration

Login

Wallet Management

Seat Management

Payment Processing

Ticket Generation

Transaction History

Booking History

File Persistence

Exception Handling
