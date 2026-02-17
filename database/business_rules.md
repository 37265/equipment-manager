# Business Rules

## Business Case
Yada yada bladeeblah. 

## Tables

### User
- Each User has a unique `email`.
- The `role` ENUM has values: `User`, `Admin`.
- Only Users with the `Admin` role can approve bookings.

### Category
- Records broad device categories, such as laptops, storage devices, and whiteboards. 

### EquipmentType
- Records the specific brand and model of a piece of equipment. 
- If `requires_approval` is false, booking the equipment can be done without admin approval.
- Each piece of equipment belongs to exactly one `Category`.

### EquipmentUnit
- Records individual pieces of equipment of one `EquipmentType`. 
- Each `EquipmentUnit` has a unique `serial_number` and `tag`. 
- The `status` ENUM has values: `Available`, and ...

### Maintenance
- Records instances where an `EquipmentUnit` needed maintenance.
- Requires a `reason` with optional `notes`.
- The `end` timestamp is nullable, because it will be set once maintenance is complete. 
- Records a creation timestamp to sort maintenance requests chronologically.
- If an `EquipmentUnit` is under `Maintenance`, it is not available. 

