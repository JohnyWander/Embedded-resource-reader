# cs_read_emb_res
Simple c# lib for reading embedded resources in .NET apps, using System.Reflection


USAGE:
reading embedded resource with example name grumpy_cat.jpg

###################################


read_emb_resource.read(grumpy_cat.jpg,read_emb_resource.option_result_string); // Converts embedded file to string <br>
string s = read_emb_resource.result_string // which is here


read_emb_resource.read("grumpy_cat.jpg",read_emb_resource.option_result_stream); // Convert embedded file to stream<br>
Stream s = read_emb_resource.result_stream // which is stored here


read_emb_resource.read("grumpy_cat.jpg",read_emb_resource.option_result_byte_array); // Convert embedded file to byte array<br>
read_emb_resource.result_byte_array // which is stored here


read_emb_resource.read("grumpy_cat.jpg",read_emb_resource.option_result_all); // use all above 




####################################
 reading embedderdresource ASYNCHROUNOUSLY -- again grumpy_cat.jgp
 
 Task task = read_em read_emb_resource_async.read("grumpy_cat.jpg",read_emb_resource.option_result_string);<br>
 // Code to do during resource read<br>
 //
 //
 await task
 
 // Code to run after resource read
