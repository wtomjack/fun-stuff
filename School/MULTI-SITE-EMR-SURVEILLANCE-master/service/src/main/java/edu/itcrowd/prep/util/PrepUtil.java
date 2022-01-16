package edu.itcrowd.prep.util;

import ca.uhn.fhir.rest.gclient.ReferenceClientParam;
import org.hl7.fhir.dstu3.model.Bundle;
import org.hl7.fhir.dstu3.model.Condition;

import java.util.Arrays;
import java.util.Date;

public class PrepUtil {

    public static int getDiffBetweenDates(Date inDate){
        Date date = new Date();
        if(inDate == null) inDate = new Date();
        int diffInDays = (int) ((date.getTime() - inDate.getTime()) / (1000l * 60 * 60 * 24 * 365) );
        return diffInDays;
    }

    public static String getConditionStatus(String patientId, String gender, String prep){
        String status= "" ;
        Bundle bundle = RestHelper.get().search().forResource(Condition.class)
                .where(new ReferenceClientParam("patient").hasId(patientId))
                .returnBundle(Bundle.class)
                .execute();

        for (Bundle.BundleEntryComponent tmp : bundle.getEntry()) {
            Condition cod = (Condition) tmp.getResource();
            if (Arrays.asList(PrepConstants.getIcd10List()).contains(cod.getCode().getCodingFirstRep().getCode())) {
                status =  "No";
                break;
            }
            if (prep.equals("prep")) {
                if (Arrays.asList(PrepConstants.getSyphilisList()).contains(cod.getCode().getCodingFirstRep().getCode())) {
                    status = "Yes";
                    break;
                }
                if (Arrays.asList(PrepConstants.getGonoList()).contains(cod.getCode().getCodingFirstRep().getCode())) {
                    status = "Yes";
                    break;
                }
                if (gender.equals("male") &&
                        Arrays.asList(PrepConstants.getChyList()).contains(cod.getCode().getCodingFirstRep().getCode())) {
                    status = "Yes";
                    break;
                }
            }
            if(prep.equals("surv")){
                if (Arrays.asList(PrepConstants.getHepBList()).contains(cod.getCode().getCodingFirstRep().getCode())) {
                    status = "No";
                    break;
                }
            }
        }
        return status;
    }
}
