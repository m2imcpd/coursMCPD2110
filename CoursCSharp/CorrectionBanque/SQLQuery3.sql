﻿SELECT c.id as clientId, c.nom, c.prenom, c.telephone, cc.id as compteId, cc.solde, 
                 o.id, o.montant, o.dateOperation    
                 FROM client as c    
                 left join compte as cc    
                 on cc.clientId = c.id    
                 left join operation as o    
                 on cc.Id = o.compteId    
                  where c.telephone = '0606060606'