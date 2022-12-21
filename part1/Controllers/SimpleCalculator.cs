/*
created by   : dwi.prash@gmail.com
created date : 2022.12.21
description  : testing application to produce rest api
note:        : still need validation here
*/


using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace part1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SimpleCalculatorController : ControllerBase
{    
    // return single number value from array of numbers input
    [HttpPost("sum")]
    public  IActionResult SumNumbers([FromBody] object payload)
    {
        try
        {
            var result = this.Calculate(payload, CalculateType.Sum);
            return result.Count == 1? new OkObjectResult(new { success = true, data = result[0]}) : NotFound();            
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
            
    }

    // return single number value from array of numbers input
    [HttpPost("subtract")]
    public  IActionResult SubtractNumbers([FromBody] object payload)
    {
        try
        {
            var result = this.Calculate(payload, CalculateType.Subtract);
            return result.Count == 1? new OkObjectResult(new { success = true, data = result[0]}) : NotFound();            
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
            
    }

    // return single number value from array of numbers input
    [HttpPost("multiply")]
    public  IActionResult MultiplyNumbers([FromBody] object payload)
    {
        try
        {
            var result = this.Calculate(payload, CalculateType.Multiply );
            return result.Count == 1? new OkObjectResult(new { success = true, data = result[0]}) : NotFound();                        
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
            
    }

    // return single number value from 2 of numbers input
    [HttpPost("divide")]
    public  IActionResult DivideNumbers([FromBody] object payload)
    {
        try
        {
            var result = this.Calculate(payload, CalculateType.Divide);
            return result.Count == 1? new OkObjectResult(new { success = true, data = result[0]}) : NotFound();
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
            
    }

    // return array of numbers value from 2 of number input
    [HttpPost("split-eq")]
    public  IActionResult SplitEqNumbers([FromBody] object payload)
    {
        try
        {
            var result = this.Calculate(payload, CalculateType.SplitEq);
            return result.Count > 1? new OkObjectResult(new { success = true, data = result[0]}) : NotFound();            
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
            
    }

    // return single number value from array of input numbers
    [HttpPost("split")]
    public  IActionResult SplitNumbers([FromBody] object payload)
    {        
        try
        {
            var result = this.Calculate(payload, CalculateType.SplitNum);
            return result.Count == 1? new OkObjectResult(new { success = true, data = result[0]}) : NotFound();
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


   enum CalculateType {Sum, Subtract, Multiply, Divide, SplitEq, SplitNum }
   private List<int> Calculate(object paramObj, CalculateType calculateType)
    {
        List<int> result = new List<int>();
         
        if (paramObj != null)
        {
            try
            {
                List<int> arrNums = JsonConvert.DeserializeObject<List<int>>(paramObj.ToString());

                if (arrNums.Count > 0)
                {            
                    if (calculateType == CalculateType.Sum)
                    {
                        result.Add(arrNums.Sum());
                        return result;
                    }

                    if (calculateType == CalculateType.Divide)
                    {
                        result.Add(arrNums[0]/arrNums[1]);
                        return result;
                    }
                     
                    if (calculateType == CalculateType.SplitEq )
                    {
                        for (int i = 0; i < arrNums[1]; i++)
                        {
                            result.Add(arrNums[0]/arrNums[1]);    
                        }
                    } else {
                    
                    int arrIdx = arrNums[0];
                    for (int i = 1; i < arrNums.Count; i++)
                    {
                        if (calculateType == CalculateType.SplitNum || calculateType == CalculateType.Subtract) 
                            arrIdx -= arrNums[i]; 
                        
                        if (calculateType == CalculateType.Multiply) 
                            arrIdx *= arrNums[i]; 
                        
                        
                        
                    }
                        result.Add(arrIdx);
                    }
                }        
            }
            catch (System.Exception ex)
            {
                throw;
            }

        }
        return result;
    }

    private List<int>? SerializeInputObject(object paramObj) {
        return paramObj != null? JsonConvert.DeserializeObject<List<int>>(paramObj.ToString()) : null;
    }

}
