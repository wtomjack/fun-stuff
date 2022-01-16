package edu.itcrowd.prep.controller;

import ca.uhn.fhir.rest.client.api.IGenericClient;
import ca.uhn.fhir.rest.gclient.ReferenceClientParam;
import ca.uhn.fhir.rest.server.exceptions.ResourceNotFoundException;
import com.fasterxml.jackson.annotation.JsonInclude;
import edu.itcrowd.prep.model.PatientDetails;
import edu.itcrowd.prep.util.PrepConstants;
import edu.itcrowd.prep.util.PrepUtil;
import edu.itcrowd.prep.util.RestHelper;
import org.hl7.fhir.dstu3.model.*;

//import edu.itcrowd.prep.util.RestHelper;
//import org.hl7.fhir.dstu3.model.Patient;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.Arrays;

@JsonInclude(JsonInclude.Include.NON_NULL)
@RestController
@RequestMapping("/api")
public class PatientController {


    @RequestMapping("/getPatientById")
    public PatientDetails getPatientById(@RequestParam(value = "id") String id) {
        PatientDetails patientDetails = new PatientDetails();

        Patient patient = null;
        try {
            patient = RestHelper.get().read().resource(Patient.class).withId(String.valueOf(id)).execute();
            int diffInDays = PrepUtil.getDiffBetweenDates(patient.getBirthDate());

            patientDetails.setAge(diffInDays);
            patientDetails.setGender(patient.getGenderElement().getValueAsString());
            patientDetails.setFirstName(patient.getNameFirstRep().getGivenAsSingleString());
            patientDetails.setLastName(patient.getNameFirstRep().getFamily());
            patientDetails.setPatientId(String.valueOf(id));
            patientDetails.setMessage("Success");
            patientDetails.setStatus("No");


            if(diffInDays >= 16 ) {

                String status  = PrepUtil.getConditionStatus(id,
                        patient.getGenderElement().getValueAsString().toLowerCase(),
                        "prep");

                patientDetails.setStatus(status.equals("") ? "No":status);

//TODO : CHECK FOR N-PEP AND PARTNER

            }

        } catch (ResourceNotFoundException r) {
            patientDetails.setMessage("patient not found");

        }

        return patientDetails;
    }



}
