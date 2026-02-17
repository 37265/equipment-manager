# Design Documentation

## Business Case

### Purpose
This database records data for an internal equipment booking system.
Users can request bookings for products like laptops, projectors, whiteboards, and a range of other equipment. 

### Workflow
Users can log in on a web app to browse equipment categories, select a specific product, and then 
request to book a unit of that product for a specific date range. The availability of a product can 
be seen in **[some implementation in the client]**, based on the number of available units, overlapping
bookings, and whether a unit is under maintenance.

For some products, bookings need to be admin-approved. The availability of such products is not directly
affected by users' booking requests. It is instead updated when an admin approves the booking. For 
products that do not require approval, users can immediately reserve a unit. 

## Diagram
The image below shows the diagram for the database. I used some maybe unconventional notations
for things like unique constraints.
- **UQ**: Column contains unique values.
- **N**: Column is nullable, and columns without **N** are `NOT NULL` by default.
- I have recorded foreign keys in the diagram, because this diagram also informs the design of the 
Model classes in my .NET server.

![diagram](./Equipment%20Booking.drawio.svg)

## Table Design

### User
- Each User has a unique `email` used for login.
- The `role` ENUM has values: 
    - `User` (can only request bookings)
    - `Admin` (can approve or deny booking requests and update maintenance tickets)
    - `Maintenance` (can update maintenance tickets)
- Only Users with `is_active == 1` can request bookings. Inactive user records are kept to track past bookings. 

### Category
- Records broad device categories, such as laptops, storage devices, and whiteboards. 

### Product
- Records the brand and model of a piece of equipment. 
- If `requires_approval` is false, a user can fully book the product without admin approval.
- Each `Product` belongs to exactly one `Category`.

### Unit
- Records individual pieces of equipment of one `Product`. 
- Each unit has a unique `tag` with a proprietary code. This would be physically applied to the unit
as a label or sticker.
- A `serial_number` can be recorded for certain products, like laptops or other electronics that have
manufacturer-assigned serial numbers.
- The `status` ENUM has values: `Active`, `Retired` (for units that have been permanently retired).

### Maintenance
- Records instances where a `Unit` is under maintenance.
- Requires a `reason` with optional `notes`.
- The `end` timestamp is nullable, because it is set once maintenance is complete. 
- Records a creation timestamp to sort maintenance requests chronologically. 

### Booking
- Records a booking by one `User` for one `Product` (and one `Unit` once approved).
- The `unit_id` foreign key for the `Unit` table is nullable, because some products require admin approval
to be booked. 
    - If the product requires approval, the foreign key is set upon approval. 
    - If the product does not require approval, it is set as soon as the user requests the booking.
- The table keeps track of the admin who approved the booking. 
- Scheduled start- and end times are recorded separately from actual pick-up and return times. 
- Unit availability is calculated as follows:
    - A unit is available if there are no other bookings overlapping the user's selected date range.
    - If `returned_at` is before `scheduled_end`, the unit is shown as available again from `returned_at`.
    - If `scheduled_end` has passed, but `returned_at` is `NULL`, the unit's `status` will not be
    shown as available until `returned_at` is recorded. This information can then be used to record
    overdue returns.
