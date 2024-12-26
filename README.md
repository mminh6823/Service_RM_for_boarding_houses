1. Project Objectives
The rental management system is designed to:

Automate the process of managing rental properties, reducing manual tasks.
Ensure accuracy and transparency in managing room, tenant, and invoice information.
Enhance the experience for both landlords and tenants through notification and utility service management features.


2. Key Features of the System
The system includes the following key features:

Room Management: Store and manage information about rooms, room types, availability status, and the number of current occupants.
Tenant Management: Maintain tenant profiles, including personal details, identification documents (ID/CCCD), and contact information.
Service Management: Track utility services such as electricity, water, and other add-on services along with their costs.
Invoice Management: Generate, store, and monitor detailed invoices covering room rent, utilities, and additional services.
Notifications: Enable landlords to send notifications to tenants about issues such as payments, new regulations, or important updates.
User Account Management: Secure access and role-based authorization for users.

3. Database Structure
The database is designed with the following main tables:

Tables TaiKhoan and TaikhoanNguoiDung: Store account information for landlords and tenants, ensuring security and controlled access.
Tables DayTro and Phong: Manage data on rental complexes and individual rooms, including their status and types.
Table LoaiPhong: Store information about room types, prices, and maximum occupancy limits.
Tables DichVu and DichVuSuDung: Track the list of services and the specific services used by each room.
Table NguoiThue: Maintain personal information of tenants.
Table DienNuoc: Record electricity and water usage and associated costs for each billing cycle.
Table ThuePhong: Track rental agreements, including rental periods and deposits.
Table HoaDon: Manage detailed invoice information such as rent, services, and other payments.
Table ThongBao: Store notifications from landlords to tenants.
![image](https://github.com/user-attachments/assets/b5f6a386-760e-458d-bd9d-f413d5c998ae)

4. Relationships Between Tables
The system uses primary and foreign keys to maintain relationships between tables:

Phong table links to LoaiPhong and DayTro for room management.
ThuePhong table connects NguoiThue and Phong to manage rental information.
DienNuoc and DichVuSuDung tables link to Phong for tracking service usage.
HoaDon table links to ThuePhong for detailed payment records.

5. Project Benefits
Optimized Management: Minimize errors and save time for landlords.
Increased Transparency: Provide clear information on costs, services, and invoices.
Enhanced User Experience: Allow tenants to easily track their rental details and payments through the system.
Scalable and Maintainable: A well-structured database design that facilitates future feature additions and system upgrades.
