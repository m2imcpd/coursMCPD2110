﻿--Q1
--SELECT TOP 10 * FROM villes_france_free order by ville_population_2012 DESC
--Q2
--SELECT TOP 50 * FROM villes_france_free order by ville_surface ASC
--Q3
--SELECT * FROM departement where departement_code like '97%'
--Q4
--SELECT TOP 10 d.departement_nom, v.ville_nom FROM villes_france_free as v left join departement as d on d.departement_code = v.ville_departement order by v.ville_population_2012 DESC
--Q5
--SELECT d.departement_nom, d.departement_code, COUNT(*) as NombreVille FROM departement as d left join villes_france_free as v on v.ville_departement = d.departement_code group by v.ville_departement, d.departement_nom, d.departement_code order by NombreVille DESC
--Q6
--SELECT TOP 10 d.departement_nom, v.ville_departement, 
--SUM(v.ville_surface) as surface 
--from villes_france_free as v 
--left join departement as d 
--on d.departement_code = v.ville_departement 
--group by d.departement_nom, v.ville_departement 
--order by surface desc 
--Q7
--SELECT count(*) from villes_france_free where ville_nom like 'saint%'
--Q8
--SELECT ville_nom, count(*) as nombre 
--from villes_france_free 
--group by ville_nom order by nombre desc 
--Q9
--SELECT v.ville_nom, v.ville_surface FROM villes_france_free as v 
--where v.ville_surface >= (SELECT AVG(ville_surface) from villes_france_free)
--Q10
--SELECT ville_departement, SUM(ville_population_2012) as nombre from villes_france_free
--group by ville_departement 
--HAVING SUM(ville_population_2012) >= 2000000 
--ORDER BY nombre DESC
--Q11
UPDATE villes_france_free 
set ville_nom = REPLACE(ville_nom,'-',' ') 
where ville_nom like 'saint%'