# QH Patient Flow Hub — Bed, Ward and Allocation Alignment Handover

* Status: Prototype alignment handover
* Current implementation point: P8 complete
* Scope: Bed Management, Ward Management, Allocation Centre, Mapping Admin backlog
* Audience: Product, design, BA, clinical stakeholders, engineering
* Important: Prototype concepts require source-system, workflow, governance and clinical validation before production

## 1. Product separation

This handover records the agreed product boundaries for the current prototype alignment. The main guardrail is that overview, ward operations, placement decision-support and administrative mapping are separate product concerns and should not be merged without explicit product, workflow and governance decisions.

### Bed Management

Primary purpose: overview and capacity coordination.

Primary question: “Where is bed pressure, capacity risk and readiness across the system?”

Owns:

* Statewide, HHS, Facility and Ward overview levels
* occupancy
* open and available capacity
* current admissions pressure
* current constraints
* cleaning, maintenance, blocked and closed capacity
* pressure and readiness summaries
* escalation and coordination context

Does not own:

* detailed ward patient operations
* direct patient placement
* unrestricted patient movement
* mapping administration

### Ward Management

Primary purpose: ward-level operational workspace.

Primary question: “What is happening on this ward, in each bed, right now?”

Owns:

* ward capacity and room context
* bed and patient list
* incoming admissions awareness
* patient identity and admitting doctor context
* room type / cohorting / isolation / specialist context
* internal transfer request
* ward-level downtime lists
* ward support access

Does not own in R2.1:

* full allocation
* unrestricted drag/drop
* direct patient movement
* final transfer confirmation
* enterprise mapping administration

### Allocation Centre

Primary purpose: placement and destination decision-support.

Primary question: “Who needs a destination, what is their allocation status, and what is blocking placement?”

Owns:

* incoming queues
* allocated / unallocated / pending-review visibility
* destination options
* date/day view concepts
* cross-ward and cross-facility placement review

Does not own:

* detailed ward bed board
* direct patient movement
* unrestricted drag/drop
* ward mapping maintenance

### Mapping Admin

Primary purpose: administrative maintenance of organisational and bed mapping.

Primary question: “How is the HHS, facility, division, ward and bed structure mapped and governed?”

This is a newly identified product area and is not yet implemented.

## 2. Completed alignment passes

### P0 — Audit

* repository and product-boundary audit
* identified Ward Operations naming and scope mismatch
* identified foundation/future-state mixing
* identified Allocation Centre and Bed Management gaps

### P1 — Product language and scope

* visible Ward Operations language changed to Ward Management
* `/ward-operations` route retained for compatibility
* R2.1 Foundation and V3 Future Whiteboard Prototype clearly separated

### P2 — Ward Management KPI model

Implemented tile order:

1. Total Physical Beds
2. Closed Beds
3. Open Beds
4. Occupied Beds
5. Expected Admissions
6. Expected Discharges
7. Isolation Beds Available
8. Specialist Beds Available
9. Outliers
10. Average Length of Stay

Some detailed breakdowns are currently local prototype data rather than shared/source-system data.

### P3 — Incoming admissions

* compact source-tab drill-down
* ED, IHT, Add-On, Ward Transfer, Elective / Planned
* allocation selectors removed from R2.1 foundation
* V3 drag/drop preserved

### P4 — Bed & Patient list

Implemented foundation columns:

* Bed / room type context
* Bed status
* Patient
* Full name
* MRN
* Date of birth
* Age
* Sex
* Admitting doctor
* Doctor name
* Doctor specialty
* Allergies & alerts
* Diet
* Action

Removed foundation columns:

* generic Team
* Referrals
* EDD
* Discharge progress
* Requests & Results
* EWS
* Waiting for

Some patient, doctor and room-type data remains local prototype data.

### P5 — Internal transfer and utilities

* controlled Request Internal Transfer panel
* request/review only
* no direct movement
* pending bed manager review state
* Ward Management foundation utilities reduced to Downtime and Support
* ward downtime limited to Admissions and discharges plus Ward patient lists
* ward support limited to Contact support
* global utilities preserved elsewhere

### P6 — Allocation Centre

* allocated / unallocated / pending-review concepts
* Today / Tomorrow / 48 hrs / Select date view controls
* destination panel remains decision-support
* no direct movement or drag/drop
* status and day controls remain prototype/static unless repository implementation confirms otherwise

### P7 — Bed Management cleanup

* ED forecast/predicted-demand language changed to current-state language
* expected-capacity language changed to current capacity/readiness language
* delayed-flow insights tied to predicted capacity removed or reframed
* future-state V3 signals preserved and labelled
* Mapping Admin and operational-status concepts protected

### P8 — Visual resilience

* Ward Management KPI, incoming, table and transfer-panel resilience
* Allocation Centre chip, date selector, lane and destination-panel resilience
* Bed Management long-label and V3-label resilience
* no rendered screenshots were available in the Codex environment
* actual build was later confirmed green externally

## 3. Ward Management R2.1 current state

Implemented:

* corrected KPI structure
* compact incoming admissions
* foundation Bed & Patient list
* room type markers
* controlled internal transfer request
* simplified Ward Management utilities

Prototype/local-data limitations:

* occupied-bed type breakdown
* isolation-bed subtype breakdown
* specialist-bed subtype breakdown
* patient identity values
* doctor values
* room type values
* transfer request persistence
* no source-system integration
* no formal workflow/audit persistence

Future-state only:

* V3 whiteboard
* drag/drop
* direct bed movement concepts
* cleaning/blocking/maintenance action workflows where not foundation-approved
* advanced operational command-board patterns

## 4. Allocation Centre current state

* lane-based queue concept
* allocation status chips
* day-view controls
* destination review
* no direct movement
* no formal placement state
* no real date filtering unless confirmed in code
* no backend/source-system integration

## 5. Bed Management current state

* multi-level Statewide/HHS/Facility/Ward structure
* current capacity and readiness emphasis
* current-state rather than predictive foundation language
* V1/V2/V3 maturity model
* V3 future-state labels
* remaining risk of overlap between Bed Management Ward level and Ward Management product

Guardrail: Ward-level Bed Management may provide summary and navigation context, but the detailed operational bed-and-patient workspace belongs to Ward Management.

## 6. New Mapping Admin requirements

Mapping Admin is a newly identified product area. It should not be added as a route, screen or model until information architecture, permissions, workflow and source-system governance are agreed.

### User/profile scope

* administrative user
* HHS and facility pre-populated from user profile
* display HHS and facility name, abbreviation and code
* show divisions, wards and beds within that facility

### Division

View/update:

* Name selected from SWMIS values
* reason required for division mapping change

Open questions:

* source of authoritative division ID/code
* whether division can be activated/deactivated
* permissions required

### Ward

View:

* ID
* Code
* Name
* Admitting Consultant
* Active

Update:

* Type
* Group
* Specialist Type
* reason required for ward mapping change

Open questions:

* authoritative source for admitting consultant
* whether Active can be edited
* definitions/value sets for Type, Group and Specialist Type
* whether one or multiple specialist types are allowed

### Bed

View:

* ID

Update:

* Group
* Type
* Attributes
* reason required for bed mapping change

Rules:

* Type defaults to Standard unless attributes indicate another type
* Attributes are multi-select
* relationship between Ward Group and Bed Group is still TBC with AF

Open questions:

* bed name/number/code fields
* active/inactive status
* whether bed attributes drive type automatically
* source and ownership of the value sets
* effective date and audit history
* approval workflow
* rollback requirements

## 7. Ward Management Operational Status extension

Future requirements:

* view HBCIS status
* update operational status
* require reason for operational status change

Likely distinction:

* HBCIS status is source-system/reference status
* operational status is the local operational status used by Patient Flow Hub
* the prototype must not imply that changing Patient Flow Hub operational status directly changes HBCIS unless integration and governance explicitly support this

Likely fields:

* HBCIS status
* current operational status
* requested/new operational status
* reason
* changed by
* changed at
* source
* audit history

Unresolved questions:

* where status is changed: Ward Management list, bed slideout, Mapping Admin, or multiple contexts
* which roles can update it
* whether approval is required
* whether change is ward-level, bed-level, or both
* how HBCIS and local status conflicts are represented
* which reasons are structured versus free text
* whether start/end dates are required
* how closures, cleaning, maintenance and blocked status relate

## 8. Governance and audit requirements

Cross-cutting governance rule: any administrative mapping change or operational status change must capture:

* previous value
* new value
* reason
* changed by
* changed at
* entity affected
* source/system
* correlation or change reference if applicable

For prototype:

* confirmation panel and local demo state are acceptable

For production, the following must be defined:

* role-based permission
* persisted audit history
* source-system ownership
* validation
* effective dates
* conflict handling
* integration behaviour

## 9. Known risks and technical debt

* `/ward-operations` route remains while visible language is Ward Management
* prototype/local values are embedded in WardOperations.razor
* Mapping Admin has no screen/model/route yet
* HBCIS status is not modelled
* operational status update is not implemented
* Allocation Centre status/date behaviour is prototype-level
* no rendered visual audit occurred in the Codex environment
* P8 added substantial CSS overrides:
  * approximately 280 lines in `bed-management.css`
  * approximately 57 lines in `bed-management-mvp.css`
* later CSS review should check:
  * duplicate selectors
  * selector conflicts
  * broad overrides
  * excessive `!important`
  * repeated media queries
  * foundation styles leaking into V3
  * `:has()` graceful fallback
* do not refactor CSS before visual regression testing

## 10. Recommended next passes

### P10 — Visual regression and screenshot audit

* capture actual rendered screenshots for:
  * Ward Management R2.1
  * Ward Management V3
  * Allocation Centre
  * Bed Management Statewide/HHS/Facility/Ward
  * light and dark modes if supported
* log visual defects only
* no feature changes

### P11 — Mapping Admin information architecture and foundation screen

* create product route/shell only after IA is agreed
* hierarchy: HHS → Facility → Division → Ward → Bed
* list/tree/detail pattern
* no overbuilt workflow
* reason-for-change pattern
* prototype data only

### P12 — Ward Management HBCIS / Operational Status

* show HBCIS status
* allow local operational-status update
* require reason
* show clear source distinction
* do not claim HBCIS write-back

### P13 — Mapping Admin data/value-set model

* SWMIS division values
* ward types/groups/specialist types
* bed groups/types/attributes
* audit/change-reason model
* permissions and source ownership

### P14 — Final visual/CSS consolidation

Only after screenshot review:

* remove duplicate overrides
* consolidate selectors
* verify responsive and dark modes
* preserve foundation/V3 separation

## 11. Decisions required from stakeholders

| Decision | Current state | Owner | Required before |
| --- | --- | --- | --- |
| Ward Group to Bed Group relationship | TBC with AF | AF / Product / BA | Mapping Admin IA and data model |
| authoritative SWMIS value sets | Not confirmed | BA / source-system owner | Mapping Admin foundation screen |
| Mapping Admin permission roles | Not defined | Product / governance / security | Any Mapping Admin implementation |
| HBCIS read/write relationship | HBCIS status not modelled; no write-back implied | Product / integration / governance | Operational status extension |
| operational-status value set | Not defined | Clinical operations / Product | Ward Management status update |
| reason-for-change value sets | Not defined | Governance / BA | Mapping or status update workflows |
| audit history visibility | Not defined | Governance / Product | Production audit design |
| whether updates require approval | Not defined | Governance / clinical operations | Mapping Admin and operational status changes |
| Allocation Centre date behaviour | Prototype-level unless repository implementation confirms otherwise | Product / BA | Production Allocation Centre design |
| production ownership of local prototype data fields | Not assigned | Product / data owners / engineering | Source-system integration planning |

## 12. Source files / implementation map

Key existing files and areas involved in the P1–P8 alignment work:

* `Pages/WardOperations.razor`
* `Pages/AllocationCentre.razor`
* `Pages/BedManagement.razor`
* `Components/BedManagement/BedManagementShell.razor`
* `Components/BedManagement/Shared/*`
* `Components/BedManagement/V1/*`
* `Components/BedManagement/V2/*`
* `Components/BedManagement/V3/*`
* `Components/Layout/PrimaryNavigation.razor`
* `Components/Layout/BottomUtilityNavigation.razor`
* `wwwroot/css/bed-management.css`
* `wwwroot/css/bed-management-mvp.css`
