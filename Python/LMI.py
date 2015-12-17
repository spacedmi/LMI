import json

with open('fields.json') as fields_file:    
    fields = json.load(fields_file)

for field in fields:
	print(field['Name'])