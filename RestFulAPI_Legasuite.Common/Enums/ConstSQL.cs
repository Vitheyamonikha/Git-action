using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI_Legasuite.Common.Enums
{
    public static class AccountsReceivableSQL
    {
        public const string
          GetLastPaidDetails = "select * from (select rpan8,rpdctm as receipt_type,rpdocm as receipt_doc,a5cmgr as credit_rep,c.drdl01 as credit_rep_name,a5clmg as credit_manager,d.drdl01 as credit_manager_name,max(date(char(rpdgj + 1900000))) receipt_date,dec(SUM(RPAG/100),15,2) receipt_amount from f0311  a join f0301 b on rpan8 = a5an8 left outer join (select * from f0005 where drsy = '56' and drrt = 'CM') c on trim(a5cmgr) = trim(c.drky) left outer join (select * from f0005 where drsy = '56' and drrt = 'CM') d on trim(a5clmg) = trim(d.drky) where rpan8 = ? and rpdctm in ('RC', 'CC') and rpdocm <> 0 and rpdgj in (select max(rpdgj) from f0311 b where b.rpan8 = a.rpan8 and b.rpdctm in ('RC', 'CC')) group by a.rpan8, a.rpdctm, a.rpdocm, b.a5cmgr, b.a5clmg, c.drdl01, d.drdl01) aa left outer join (select rpan8, dec(SUM(RPAG/100),15,2) late_charge from f0311 where rpan8 = ? and rpdct = 'RF' and rpdocm = 0 group by rpan8) bb on aa.rpan8 = bb.rpan8",
          GetReceiptDetails = "select rpan8, rpdoc Invoice_Number, rpdct Doc_Type, rpsfx Suffix, dec((rpag/100 * -1),15,2) InvMatch_Amount,date(char(rpdgj + 1900000)) Receipt_Date, date(char(rpdgj + 1900000)) GL_Date, RPCRCD Currency_Code from f0311 a where rpan8 = ? and rpdocm = ? and rpdctm = ? and date(char(rpdgj + 1900000)) = ?",
          GetLastPaidDate = "select max(date(char(rpdgj + 1900000))) from f0311 b where rpan8 = ? and rpdocm = ? and rpdctm in ('RC', 'CC')";
    }
}

