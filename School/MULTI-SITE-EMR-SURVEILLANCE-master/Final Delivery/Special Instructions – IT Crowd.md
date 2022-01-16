# Special Instructions

MULTI-SITE EMR SURVEILLANCE AND CLINICAL DECISION SUPPORT FOR HIV PREEXPOSURE PROPHYLAXIS (PrEP). 

## Installation

- Prerequisites
  - [Docker](https://docs.docker.com/install/)
  - [Maven](https://maven.apache.org/download.cgi)
  - [JDK-1.8](http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html)
  
## Usage

To run application from **Command-Line Interface** (CLI) via `docker-compose`:

- Build the application through your CLI: `docker-compose up`
- Use [`rebuild.sh`](rebuild.sh) to stop, rebuild and start containers.
- WARNING: Use [`clean.sh`](clean.sh) to kill and remove containers and images.

To run [**Website**](/website) separately via **Dockerfile**

- `cd` in website directory
- To build image for website run: `docker build -t <image-name> .`
  - Example: `docker build -t website .`
- To run docker image on container: `docker run -p 80:80 <image-id> or <image-name>`
  - `-p` port argument can be specified any
  - `-d` argument can be used with detached mode
  - Example: `docker run -p 80:80 website`
- After successful build & deploy, website can be accessed on `http://localhost:80/`

To start [**PrEP Web service**](/service) separately via **Dockerfile**

- `cd` in service folder
- To build image for website run: `docker build -t <image-name> .`
  - Example: `docker build -t service .`
- To run docker image on container: `docker run -p 8080:8080 <image-id> or <image-name>`
  - `-p` port argument can be specified any
  - `-d` argument can be used with detached mode
  - Example: `docker run -p 8080:8080 service`
- After successful build & deploy, website can be accessed on `http://localhost:8080/api/<endpoint>`

To validate successful build with maven: `mvn clean verify`

## API

- Example local endpoints:
  - Patients for Surveillance [http://localhost:8080/api/getPatientDetailsList](http://localhost:8080/api/getPatientDetailsList)
  - Qualified patient for PrEP [http://localhost:8080/api/getPatientById?id=1e19bb7a-d990-4924-9fae-be84f19c53c1](http://localhost:8080/api/getPatientById?id=1e19bb7a-d990-4924-9fae-be84f19c53c1)
  - Unqualified patient for PrEP [http://localhost:8080/api/getPatientById?id=30d44805-5e26-4f59-9cac-6ce7bd9b105](http://localhost:8080/api/getPatientById?id=30d44805-5e26-4f59-9cac-6ce7bd9b1052)
- Example production endpoints:
  - Patients for Surveillance [https://cs6440-s18-prj12.apps.hdap.gatech.edu/api/getPatientDetailsList](https://cs6440-s18-prj12.apps.hdap.gatech.edu/api/getPatientDetailsList)
  - Qualified patient for PrEP [https://cs6440-s18-prj12.apps.hdap.gatech.edu/api/getPatientById?id=1e19bb7a-d990-4924-9fae-be84f19c53c1](https://cs6440-s18-prj12.apps.hdap.gatech.edu/api/getPatientById?id=1e19bb7a-d990-4924-9fae-be84f19c53c1)
  - Unqualified patient for PrEP [https://cs6440-s18-prj12.apps.hdap.gatech.edu/api/getPatientById?id=30d44805-5e26-4f59-9cac-6ce7bd9b105](https://cs6440-s18-prj12.apps.hdap.gatech.edu/api/getPatientById?id=30d44805-5e26-4f59-9cac-6ce7bd9b1052)

## Expanding 

To expand the algorithm to search more DiagnosticReport modify `ObservationController.java`:

    /* Add new DiagnosticReport here.
     *
     * Bundle chy = RestHelper.get().search().forResource(DiagnosticReport.class)
     * .where(new TokenClientParam("code").exactly().code("39224-1"))
     * .where(new ReferenceClientParam("patient").hasId(patient.getIdElement().getIdPart()))
     * .returnBundle(Bundle.class)
     * .execute();
     *
     * date1 = chy.hasEntry()?simpleDateFormat.format(chy.getEntry().get(0).getResource().getMeta().getLastUpdated()):"N/A";
     * patientDetails.setChyDate(date1);
     */

To expand the algorithm to search more MedicationRequest modify `ObservationController.java`:

    /* Add new MedicationRequest here.
     *
     * Bundle bundle = RestHelper.get().search().forResource(MedicationRequest.class)
     * .where(new TokenClientParam("code").exactly().code("<code-id>"))
     * .returnBundle(Bundle.class)
     * .execute();
     */
     
To expand the algorithm to search more ICD-10, Chlamydia, Gonorrhea, Syphilis, and Hepatitis codes `PrepConstants.java`:
    
    // example
    final static String icd10List []= { "042",
            "795.71",
            "V08",
            "079.53",
            "B20",
            ...<more codes here>
            ...
            ...
    }

## Contribution

RECOMMENDED WAY. NOT REQUIRED: Please contribute using [Github Flow](https://guides.github.com/introduction/flow/). Create a fork, add commits, and [open a pull request](https://github.com/fraction/readme-boilerplate/compare/).