# Project Execution

1. Create a Movie Obj
2. Create a Theater Obj
3. Create Show Obj
4. Create Booking Obj
5. Create Payment Service Obj
6. Create Notifications Service Obj
7. Create File Service Obj
8. Dependencies Injection into BookingService
9. Call BookTicket()
10. Validate Booking
11. Process Payment
12. Send Notifications
13. Save Booking To File
14. Display Booking History

Program Ends
--------------------;

            IPaymentService
                    ▲
                    │
                    │
      ----------------------------
      │            │             │
      │            │             │
      ▼            ▼             ▼

UpiPayment CardPayment WalletPayment

----------------------------------------;

      INotificationService
                    ▲
                    │
                    ▼

      EmailNotificationService

-----------------;
IPaymentService
▲
│
│ implements
│

UpiPaymentService

---

IPaymentService
▲
│
│ implements
│

CardPaymentService

---

INotificationService
▲
│
│ implements
│

EmailNotificationService
------------------;
BookTicket()
↓
Validate Ticket Count
↓
Validate Amount
↓
Process Payment
↓
Send Notification
↓
Prepare Booking Record
↓
Save To File
↓
Success Message

------------;

Create Movie
↓
Create Theater
↓
Create Show
↓
Create Booking
↓
Create Services
↓
Inject Dependencies
↓
Call BookTicket()
↓
Read Booking History
↓
Display Output

-------------;
Asst enhance:

1. Payment Menu (UPI/Card)

2. Notification Menu (Email/SMS)

3. User Input from Console

4. Multiple Bookings

5. View History Option

6. Exit Option

7. Proper Main Menu
