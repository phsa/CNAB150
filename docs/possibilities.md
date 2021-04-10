
/**
 * ADAPTER TO GET A DATABASE ENTITY (ONLY ENUMS) AND MAP TO CnabRecordRule (MAYBE ITS JUST A MAPPER)
 * 
 * ADAPTER TO PASS INTEGERS, DOUBLES AND DATETIMES AND CONVERT TO PROPER FORMAT USING MAY DEFINED INTO CnabRecordRule OR OUTSIDE IT
 *      adapter.Apply(int value)
 *      {
 *          rule.Apply(value.ToString());
 *      }
 * 
 *      adapter.Apply(DateTime value)
 *      {
 *          rule.Apply(value.ToString(format));
 *      }
 * 
 *      adapter.Apply(string value)
 *      {
 *          COULD INSTEAD OF IMPLEMENTING AN ADAPTER INTERFACE, EXTENDS CnabRecordRule
 *      }
 *      
 *  COULD BE NON-STRING FORMATTER OBJECT, RECEIVES AN OBJECT IF IT A DATETIME, AN INTEGER OR A DOUBLE 
 *      
 *      
 * You can use Abstract Factory along with Bridge. This pairing is useful 
 * when some abstractions defined by Bridge can only work with specific implementations. 
 * In this case, Abstract Factory can encapsulate these relations and hide the complexity 
 * from the client code.
 * 
 * BRIDGE TO STABLISH THE RELATION BETWEEN BANKS AND CNABS
 * 
 * BUILDER TO BUILD CnabRecordRule STEP BY STEP
 * 
 * STRATEGY TO DEFINE METHODS/STRATEGIES IN A CnabRecordRule (ALREADY DONE WITH DELEGATES)
 * 
 * EXPAND THE FILLING POSSIBILITIES, USE A ENUM
 *
 * USE A CNAB OBJECT AS BRIDGE TO CONNECT AND COMMUNICATE CNAB DATA (BANK INFO, OPERATIONS, CUSTOMER INFO) TO CNAB LAYOUTS
 *
 * 
 * */