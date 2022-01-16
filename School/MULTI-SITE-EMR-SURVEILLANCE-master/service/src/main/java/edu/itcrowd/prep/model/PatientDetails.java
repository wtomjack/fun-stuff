package edu.itcrowd.prep.model;

import com.fasterxml.jackson.annotation.JsonInclude;

import java.util.Date;
import java.util.List;

@JsonInclude(JsonInclude.Include.NON_NULL)

public class PatientDetails {
    private String firstName;
    private String lastName;
    private Integer age;
    private String zipCode;
    private Date firstPrescriptionDate;
    private Date recentPrescriptionDate;

    public String getHepBDate() {
        return hepBDate;
    }

    public void setHepBDate(String hepBDate) {
        this.hepBDate = hepBDate;
    }

    private String hepBDate;

    public String getChyDate() {
        return chyDate;
    }

    public void setChyDate(String chyDate) {
        this.chyDate = chyDate;
    }

    public String getHivDate() {
        return hivDate;
    }

    public void setHivDate(String hivDate) {
        this.hivDate = hivDate;
    }

    public String getSpyDate() {
        return spyDate;
    }

    public void setSpyDate(String spyDate) {
        this.spyDate = spyDate;
    }

    private String chyDate;
    private String hivDate;
    private String spyDate;

    public String getGonDate() {
        return gonDate;
    }

    public void setGonDate(String gonDate) {
        this.gonDate = gonDate;
    }

    private String gonDate;
    private String patientId;
    private String facilityName;
    private List<String> tests;

    public void setDateList(List<String> dateList) {
        this.dateList = dateList;
    }

    public List<String> getDateList() {
        return dateList;
    }

    private List<String> dateList;


    public String getFacilityName() {
        return facilityName;
    }

    public void setFacilityName(String facilityName) {
        this.facilityName = facilityName;
    }

    public List<String> getTests() {
        return tests;
    }

    public void setTests(List<String> tests) {
        this.tests = tests;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    private String message;

    public String getGender() {
        return gender;
    }

    public void setGender(String gender) {
        this.gender = gender;
    }

    private String gender;


    public String getPatientId() {
        return patientId;
    }

    public void setPatientId(String patientId) {
        this.patientId = patientId;
    }


    public String getZipCode() {
        return zipCode;
    }

    public void setZipCode(String zipCode) {
        this.zipCode = zipCode;
    }

    public Date getFirstPrescriptionDate() {
        return firstPrescriptionDate;
    }

    public void setFirstPrescriptionDate(Date firstPrescriptionDate) {
        this.firstPrescriptionDate = firstPrescriptionDate;
    }

    public Date getRecentPrescriptionDate() {
        return recentPrescriptionDate;
    }

    public void setRecenttPrescriptionDate(Date recenttPrescriptionDate) {
        this.recentPrescriptionDate = recenttPrescriptionDate;
    }

    public String getRace() {
        return race;
    }

    public void setRace(String race) {
        this.race = race;
    }

    private String race;

    public Integer getAge() {
        return age;
    }

    public void setAge(Integer age) {
        this.age = age;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    private String status;


    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }
}
