Feature: Add new computer

@AddANewComputer
#Just example of a simple test case to add a new computer with all fields filled in correctly
Scenario: Add new computer with all correct fields
	Given I set the computer name to "Specflow_NewComputer" 
	And I set the Introduced date to "2015-11-18"
	And I set the Discontinued date to "2016-11-18"
	And I set the Company to "1"
	When I press Create this computer
	Then response message should contain "Done!"
	And response code should be "OK"

@PositiveCases
#Test set: Add new computer
#Expected: "Done", Status code OK
#In this set we are using one scenario and table of variables for different test-cases
Scenario Outline: Add a new computer positive flow
	Given I set the computer name to "<name>" 
	And I set the Introduced date to "<introduced>"
	And I set the Discontinued date to "<discontinued>"
	And I set the Company to "<company>"
	When I press Create this computer
	Then response message should contain "Done!"
	And response code should be "OK"
Examples:
| example description                  | name                         | introduced | discontinued | company |
| 0_Empty_Introduced_Date              | Specflow_EmptyIntroduced     |            | 2016-11-18   | 1       |
| 1_Empty_Discontinued_Date            | Specflow_EmptyDiscontinued   | 2015-11-18 |              | 2       |
| 2_Empty_Company                      | Specflow_EmptyCompany        | 2015-11-18 | 2016-11-18   |         |
| 3_Empty_Dates                        | Specflow_EmptyDates          |            |              | 3       |
| 4_Empty_DiscontinuedDate_And_Company | Specflow_EmptyDiscontCompany | 2015-11-18 |              |         |
| 5_Empty_IntroducedDate_And_Company   | Specflow_EmptyIntrodCompany  |            | 2016-11-18   |         |
| 6_Only_Name                          | Specflow_Only_Name           |            |              |         |

@DatesTesting
#Test set: Dates testing
#Expected: Fail or pass, as descrobed in columns
#In this test set we will test dates in different combinations
Scenario Outline: Add a new computer, dates testing
	Given I set the computer name to "<name>" 
	And I set the Introduced date to "<introduced>"
	And I set the Discontinued date to "<discontinued>"
	And I set the Company to "1"
	When I press Create this computer
	Then response message should contain "<expected_response>"
	And response code should be "<expected_code>"
Examples:
| example description            | name                           | introduced  | discontinued | expected_response | expected_code |
| 0_Normal_Dates                 | Specflow_Normal_Dates          | 2015-11-18  | 2016-11-18   | Done!             | OK            |
| 1_Zero_Year                    | Specflow_Zero_Year             | 0-1-1       | 9999-12-12   | Done!             | OK            |
| 2_Intro_DateFormat_dd-MM-yyyy  | Specflow_DateFormat_dd-MM-yyyy | 31-12-2000  |              |                   | 400           |
| 3_Disc_DateFormat_dd-MM-yyyy   | Specflow_DateFormat_dd-MM-yyyy |             | 31-12-2000   |                   | 400           |
| 4_Intro_Text_Month             | Specflow_Text_Month            | 2015-Nov-18 |              |                   | 400           |
| 5_Disc_Intro_Text_Month        | Specflow_Intro_Text_Month      |             | 2015-Nov-18  |                   | 400           |
| 6_Intro_Negative_Year          | Specflow_Negative_Year         | -1-11-11    |              |                   | 400           |
| 7_Disc_Negative_Year           | Specflow_Negative_Year         |             | -1-11-11     |                   | 400           |
| 8_Intro_Wrong_Delimiter        | Specflow_Wrong_Delimiter       | 2000/1/1    |              |                   | 400           |
| 9_Disc_Wrong_Delimiter         | Specflow_Wrong_Delimiter       |             | 2000/1/1     |                   | 400           |
| 10_Intro_Text_Date             | Specflow_Text_Date             | text        |              |                   | 400           |
| 11_Intro_Text_Date             | Specflow_Text_Date             |             | text         |                   | 400           |
| 12_Intro_DateFormat_dd-MM-yyyy | Specflow_DateFormat_MM-dd-yyyy | 12-31-2000  |              |                   | 400           |
| 13_Disc_DateFormat_dd-MM-yyyy  | Specflow_DateFormat_MM-dd-yyyy |             | 12-31-2000   |                   | 400           |
| 14_Intro_Space_Delimiter       | Specflow_Space_Delimiter       | 2000 1 1    |              |                   | 400           |
| 15_Disc_Space_Delimiter        | Specflow_Space_Delimiter       |             | 2000 1 1     |                   | 400           |
| 16_Intro_30_Feb                | Specflow_30_Feb                | 2012-2-30   |              |                   | 400           |
| 16_Disc_30_Feb                 | Specflow_30_Feb                |             | 2012-2-30    |                   | 400           |

@CompanyTesting
#Test set: Company field testing
#Expected: Company is not mandatory field it will pass with any number
Scenario Outline: Add new computer, company field testing
	Given I set the computer name to "Specflow_CompanyTesting" 
	And I set the Introduced date to "2015-11-18"
	And I set the Discontinued date to "2016-11-18"
	And I set the Company to "<company>"
	When I press Create this computer
	Then response message should contain "<expected_response>"
	And response code should be "<expected_code>"
Examples: 
| example description        | company | expected_response | expected_code |
| 0_Company_0                | 0       | Done!             | OK            |
| 1_Negative_Company         | -1      | Done!             | OK            |
| 2_Company_Code_Not_in_List | 9999999 | Done!             | OK            |
| 3_Company_Code_is_Text     | text    |                   | 400           |