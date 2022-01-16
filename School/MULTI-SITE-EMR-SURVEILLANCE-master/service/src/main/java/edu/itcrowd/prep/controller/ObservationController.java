package edu.itcrowd.prep.controller;

import ca.uhn.fhir.rest.gclient.ReferenceClientParam;
import ca.uhn.fhir.rest.gclient.TokenClientParam;
import edu.itcrowd.prep.model.PatientDetails;
import edu.itcrowd.prep.model.Tests;
import edu.itcrowd.prep.util.PrepUtil;
import edu.itcrowd.prep.util.RestHelper;
import org.hl7.fhir.dstu3.model.*;
import org.hl7.fhir.exceptions.FHIRException;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping("/api")
public class ObservationController {

    @RequestMapping("/getPatientDetailsList")
    public List<PatientDetails> getPatientDetailsList() {
        List<PatientDetails> patientDetailsList = new ArrayList<>();
        String status ;

        Bundle bundle = RestHelper.get().search().forResource(MedicationRequest.class)
                .where(new TokenClientParam("code").exactly().code("639888"))
                .returnBundle(Bundle.class)
                .execute();

        /* Add new MedicationRequest here.
         *
         * Bundle bundle = RestHelper.get().search().forResource(MedicationRequest.class)
         * .where(new TokenClientParam("code").exactly().code("<code-id>"))
         * .returnBundle(Bundle.class)
         * .execute();
         */

        for (Bundle.BundleEntryComponent tmp : bundle.getEntry()) {
            MedicationRequest medicationRequest = (MedicationRequest) tmp.getResource();
            PatientDetails patientDetails = new PatientDetails();

            Patient patient = RestHelper.get().read().resource(Patient.class)
                    .withId(medicationRequest.getSubject().getReference().substring(8)).execute();
            String pattern = "yyyy-MM-dd";
            SimpleDateFormat simpleDateFormat = new SimpleDateFormat(pattern);
            int diffInDays = PrepUtil.getDiffBetweenDates(patient.getBirthDate());

            if (diffInDays > 16) {

                status = PrepUtil.getConditionStatus(patient.getIdElement().getIdPart(),
                        patient.getGenderElement().getValueAsString(),
                        "surv");

                if (!status.equals("No")) {
                    patientDetails.setAge(diffInDays);
                    List<String> dateList = new ArrayList<>();
                    patientDetails.setGender(patient.getGenderElement().getValueAsString());
                    patientDetails.setZipCode(patient.getAddressFirstRep().getPostalCode());
                    patientDetails.setFacilityName("Mayo Clinic");
                    Bundle meds = RestHelper.get().search().forResource(MedicationRequest.class)
                            .where(new ReferenceClientParam("subject").hasId(patient.getIdElement().getIdPart()))
                            .where(new TokenClientParam("code").exactly().code("639888"))
                            .returnBundle(Bundle.class)
                            .execute();

                    for (Bundle.BundleEntryComponent tmp1 : meds.getEntry()) {
                        MedicationRequest medicationRequest1 = (MedicationRequest) tmp1.getResource();


                        String date = simpleDateFormat.format(medicationRequest1.getMeta().getLastUpdated());
                        dateList.add(date);
                    }

                    Bundle hepB = RestHelper.get().search().forResource(DiagnosticReport.class)
                            .where(new TokenClientParam("code").exactly().code("50967-9"))
                            .where(new ReferenceClientParam("patient").hasId(patient.getIdElement().getIdPart()))
                            .returnBundle(Bundle.class)
                            .execute();


                    String date1 = hepB.hasEntry() ? simpleDateFormat.format(hepB.getEntryFirstRep().getResource().getMeta().getLastUpdated()):"N/A";
                    patientDetails.setHepBDate(date1);

                    Bundle gonB = RestHelper.get().search().forResource(DiagnosticReport.class)
                            .where(new TokenClientParam("code").exactly().code("39225-8"))
                            .where(new ReferenceClientParam("patient").hasId(patient.getIdElement().getIdPart()))
                            .returnBundle(Bundle.class)
                            .execute();

                    date1 = gonB.hasEntry()? simpleDateFormat.format(gonB.getEntry().get(0).getResource().getMeta().getLastUpdated()):"N/A";
                    patientDetails.setGonDate(date1);

                    Bundle hiv = RestHelper.get().search().forResource(DiagnosticReport.class)
                            .where(new TokenClientParam("code").exactly().code("33660-2"))
                            .where(new ReferenceClientParam("patient").hasId(patient.getIdElement().getIdPart()))
                            .returnBundle(Bundle.class)
                            .execute();

                     date1 = hiv.hasEntry()?simpleDateFormat.format(hiv.getEntry().get(0).getResource().getMeta().getLastUpdated()):"N/A";
                    patientDetails.setHivDate(date1);

                    Bundle chy = RestHelper.get().search().forResource(DiagnosticReport.class)
                            .where(new TokenClientParam("code").exactly().code("39224-1"))
                            .where(new ReferenceClientParam("patient").hasId(patient.getIdElement().getIdPart()))
                            .returnBundle(Bundle.class)
                            .execute();

                    date1 = chy.hasEntry()?simpleDateFormat.format(chy.getEntry().get(0).getResource().getMeta().getLastUpdated()):"N/A";
                    patientDetails.setChyDate(date1);

                    Bundle en = RestHelper.get().search().forResource(Encounter.class)
                            .where(new ReferenceClientParam("patient").hasId(patient.getIdElement().getIdPart()))
                            .returnBundle(Bundle.class)
                            .execute();

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

                    patientDetails.setDateList(dateList);
                    patientDetailsList.add(patientDetails);

                }
            }
        }

        return patientDetailsList;
    }


}
