package edu.itcrowd.prep.util;

import ca.uhn.fhir.context.FhirContext;
import ca.uhn.fhir.rest.client.api.IGenericClient;

public class RestHelper {

    public static IGenericClient get(){
        String baseUrl ="https://apps.hdap.gatech.edu/syntheticmass/baseDstu3";
        //String baseUrl = "http://hapi.fhir.org/baseDstu3";
        FhirContext ctx = FhirContext.forDstu3();
        return ctx.newRestfulGenericClient(baseUrl);
    }

}
