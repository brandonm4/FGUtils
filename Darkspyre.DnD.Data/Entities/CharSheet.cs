using Darkspyre.DnD.Data.Entities.Darkspyre.DnD.Data.CharSheetData;
using Darkspyre.DnD.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Darkspyre.DnD.Data.Entities
{
    public class CharSheet : BaseEntity, IName
    {
        public string Holder { get; set; }
        public List<AbilityScore> Abilities { get; set; } = new List<AbilityScore>();
        public string Alignment { get; set; }
        public string Background { get; set; }
        public RecordLink BackgroundLink { get; set; }
        public string Bonds { get; set; }
        public List<CharSheetClass> Classes { get; set; } = new List<CharSheetClass>();
        public string CoinOther { get; set; }
        public int CurHP { get; set; }
        public int CurrentEdit { get; set; }
        public string DCI { get; set; }

        public string Name { get; set; }

        
        public int Age { get; set; }
public string Appearance { get; set; }
        public List<CoinSlot> Coins { get; set; } = new List<CoinSlot>();
        /*
	
			
			<defenses>
				<ac>
					<armor type="number">3</armor>
					<dexbonus type="string">max2</dexbonus>
					<disstealth type="number">0</disstealth>
					<misc type="number">0</misc>
					<prof type="number">1</prof>
					<shield type="number">0</shield>
					<temporary type="number">0</temporary>
					<total type="number">15</total>
				</ac>
			</defenses>
			<deity type="string">Ohgma</deity>
			<effectlist>
				<id-00001>
					<effect_description type="string">[]</effect_description>
					<name type="string">Bob</name>
				</id-00001>
			</effectlist>
			<encumbrance>
				<encumbered type="number">75</encumbered>
				<encumberedheavy type="number">150</encumberedheavy>
				<liftpushdrag type="number">450</liftpushdrag>
				<load type="number">81</load>
				<max type="number">225</max>
			</encumbrance>
			<exp type="number">0</exp>
			<expneeded type="number">0</expneeded>
			<faction type="string">Faction Text Here</faction>
			<featlist>
			</featlist>
			<featurelist>
				<id-00001>
					<level type="number">1</level>
					<locked type="number">1</locked>
					<name type="string">Spellcasting</name>
					<source type="string">Wizard</source>
					<text type="formattedtext">
						<p>As a student of arcane magic, you have a spellbook containing spells that show the first glimmerings of your true power. See chapter 10 for the general rules of spellcasting and chapter 11 for the wizard spell list.</p>
						<linklist>
							<link class="reference_colindex" recordname="reference.spelllists.wizard@BMDC Player Guide">Wizards Spells</link>
						</linklist>
						<p><b>Cantrips</b></p>
						<p>At 1st level, you know three cantrips of your choice from the wizard spell list. You learn additional wizard cantrips of your choice at higher levels, as shown in the Cantrips Known column of the Wizard table.</p>
						<p><b>Spellbook</b></p>
						<p>At 1st level, you have a spellbook containing six 1st-level wizard spells of your choice.</p>
						<p><b>Preparing and Casting Spells</b></p>
						<p>The Wizard table shows how many spell slots you have to cast your spells of 1st level and higher. To cast one of these spells, you must expend a slot of the spell's level or higher. You regain all expended spell slots when you finish a long rest.</p>
						<p>You prepare the list of wizard spells that are available for you to cast. To do so, choose a number of wizard spells from your spellbook equal to your Intelligence modifier + your wizard level (minimum of one spell). The spells must be of a level for which you have spell slots.</p>
						<p>For example, if you're a 3rd-level wizard, you have four 1st-level and two 2nd-level spell slots. With an Intelligence of 16, your list of prepared spells can include six spells of 1st or 2nd level, in any combination, chosen from your spellbook. If you prepare the 1st-level spell magic missile, you can cast it using a 1st-level or a 2nd-level slot. Casting the spell doesn't remove it from your list of prepared spells.</p>
						<p>You can change your list of prepared spells when you finish a long rest. Preparing a new list of wizard spells requires time spent studying your spellbook and memorizing the incantations and gestures you must make to cast the spell: at least 1 minute per spell level for each spell on your list.</p>
						<p><b>Spellcasting Ability</b></p>
						<p>Intelligence is your spellcasting ability for your wizard spells, since you learn your spells through dedicated study and memorization. You use your Intelligence whenever a spell refers to your spellcasting ability.</p>
						<p>In addition, you use your Intelligence modifier when setting the saving throw DC for a wizard spell you cast and when making an attack roll with one.</p>
						<p><b>Spell save DC </b>= 8 + your proficiency bonus + your Intelligence modifier</p>
						<p><b>Spell attack modifier </b>= your proficiency bonus + your Intelligence modifier</p>
						<p><b>Ritual Casting</b></p>
						<p>You can cast a wizard spell as a ritual if that spell has the ritual tag and you have the spell in your spellbook. You don't need to have the spell prepared.</p>
						<p><b>Spellcasting Focus</b></p>
						<p>You can use an arcane focus (found in chapter 5) as a spellcasting focus for your wizard spells.</p>
						<p><b>Learning Spells of 1st Level and Higher</b></p>
						<p>Each time you gain a wizard level, you can add two wizard spells of your choice to your spellbook. Each of these spells must be of a level for which you have spell slots, as shown on the Wizard table. On your adventures, you might find other spells that you can add to your spellbook (see the &#34;Your Spellbook&#34; sidebar).</p>
						<h>Your Spellbook</h>
						<p>The spells that you add to your spellbook as you gain levels reflect the arcane research you conduct on your own, as well as intellectual breakthroughs you have had about the nature of the multiverse. You might find other spells during your adventures. You could discover a spell recorded on a scroll in an evil wizard's chest, for example, or in a dusty tome in an ancient library.</p>
						<p><b><i>Copying a Spell into the book. </i></b>When you find a wizard spell of 1st level or higher, you can add it to your spellbook if it is of a level for which you have spell slots and if you can spare the time to decipher and copy it. The spells copied into a spellbook must be of a spell level the wizard can prepare.</p>
						<p>Copying a spell into your spellbook involves reproducing the basic form of the spell, then deciphering the unique system of notation used by the wizard who wrote it. You must practice the spell until you understand the sounds or gestures required, then transcribe it into your spellbook using your own notation.</p>
						<p>For each level of the spell, the process takes 2 hours and costs 50gp. The cost represents material components you expend as you experiment with the spell to master it, as well as the fine inks you need to record it. Once you have spent this time and money, you can prepare the spell just like your other spells.</p>
						<p><b><i>Replacing the Book. </i></b>You can copy a spell from your own spellbook into another book-for example, if you want to make a backup copy of your spellbook. This is just like copying a new spell into your spellbook, but faster and easier, since you understand your own notation and already know how to cast the spell. You need spend only 1 hour and 10 gp for each level of the copied spell. If you lose your spellbook, you can use the same procedure to transcribe the spells that you have prepared into a new spellbook. Filling out the remainder of your spellbook requires you to find new spells to do so, as normal. For this reason, many wizards keep backup spellbooks in a safe place.</p>
						<p><b><i>The Book's Appearance </i></b>Your spellbook is a unique compilation of spells, with its own decorative flourishes and margin notes. It might be a plain, functional leather volume that you received as a gift from your master, a finely bound gilt-edged tome you found in an ancient library, or even a loose collection of notes scrounged together after you lost your previous spellbook in a mishap.</p>
						<p>A spellbook doesn't contain cantrips.</p>
					</text>
				</id-00001>
				<id-00002>
					<level type="number">1</level>
					<locked type="number">1</locked>
					<name type="string">Arcane Recovery</name>
					<source type="string">Wizard</source>
					<text type="formattedtext">
						<p>You have learned to regain some of your magical energy by studying your spellbook. Once per day when you finish a short rest, you can choose expended spell slots to recover. The spell slots can have a combined level that is equal to or less than half your wizard level (rounded up), and none of the slots can be 6th level or higher.</p>
						<p>For example, if you're a 4th-level wizard, you can recover up to two levels worth of spell slots. You can recover either a 2nd-level spell slot or two 1st-level spell slots.</p>
					</text>
				</id-00002>
				<id-00003>
					<locked type="number">1</locked>
					<name type="string">Position of Privilege</name>
					<source type="string">Noble</source>
					<text type="formattedtext">
						<p>Thanks to your noble birth, people are inclined to think the best of you. You are welcome in high society, and people assume you have the right to be wherever you are. The common folk make every effort to accommodate you and avoid your displeasure, and other people of high birth treat you as a member of the same social sphere. You can secure an audience with a local noble if you need to.</p>
					</text>
				</id-00003>
				<id-00004>
					<locked type="number">1</locked>
					<name type="string">Retainers</name>
					<source type="string">Noble</source>
					<text type="formattedtext">
						<p>If your character has a noble background, you may select this background feature instead of Position of Privilege.</p>
						<p>You have the service of three retainers loyal to your family. These retainers can be attendants or messengers, and one might be a majordomo. Your retainers are commoners who can perform mundane tasks for you, but they do not fight for you, will not follow you into obviously dangerous areas (such as dungeons), and will leave if they are frequently endangered or abused.</p>
					</text>
				</id-00004>
			</featurelist>
			<flaws type="string">I have an insatiable desire for carnal pleasures.</flaws>
			<gender type="string">Male</gender>
			<height type="string">6'1&#34;</height>
			<hp>
				<deathsavefail type="number">0</deathsavefail>
				<deathsavesuccess type="number">0</deathsavesuccess>
				<temporary type="number">0</temporary>
				<total type="number">16</total>
				<wounds type="number">0</wounds>
			</hp>
			<hpEdit type="number">0</hpEdit>
			<ideals type="string">Respect. Respect is due to me because of my position, but all people regardless of station deserve to be treated with dignity. (Good)</ideals>
			<initiative>
				<misc type="number">0</misc>
				<temporary type="number">0</temporary>
				<total type="number">4</total>
			</initiative>
			<inspiration type="number">1</inspiration>
			<inventorylist>
				<id-00001>
					<carried type="number">1</carried>
					<cost type="string">1 gp</cost>
					<count type="number">1</count>
					<isidentified type="number">1</isidentified>
					<locked type="number">1</locked>
					<name type="string">Bedroll</name>
					<subtype type="string">Standard</subtype>
					<type type="string">Adventuring Gear</type>
					<weight type="number">7</weight>
				</id-00001>
				<id-00002>
					<carried type="number">1</carried>
					<cost type="string">5 sp</cost>
					<count type="number">10</count>
					<description type="formattedtext">
						<p>Rations consist of dry foods suitable for extended travel, including jerky, dried fruit, hardtack, and nuts.</p>
					</description>
					<isidentified type="number">1</isidentified>
					<locked type="number">1</locked>
					<name type="string">Rations (1 Day)</name>
					<subtype type="string">Standard</subtype>
					<type type="string">Adventuring Gear</type>
					<weight type="number">2</weight>
				</id-00002>
				<id-00003>
					<carried type="number">1</carried>
					<cost type="string">1 cp</cost>
					<count type="number">10</count>
					<description type="formattedtext">
						<p>A torch burns for 1 hour, providing bright light in a 20-foot radius and dim light for an additional 20 feet. If you make a melee attack with a burning torch and hit, it deals 1 fire damage.</p>
					</description>
					<isidentified type="number">1</isidentified>
					<locked type="number">1</locked>
					<name type="string">Torch</name>
					<subtype type="string">Standard</subtype>
					<type type="string">Adventuring Gear</type>
					<weight type="number">1</weight>
				</id-00003>
				<id-00004>
					<carried type="number">1</carried>
					<cost type="string">5 sp</cost>
					<count type="number">1</count>
					<description type="formattedtext">
						<p>This small container holds flint, fire steel, and tinder (usually dry cloth soaked in light oil) used to kindle a fire. Using it to light a torch-or anything else with abundant, exposed fuel-takes an action. Lighting any other fire takes 1 minute.</p>
					</description>
					<isidentified type="number">1</isidentified>
					<locked type="number">1</locked>
					<name type="string">Tinderbox</name>
					<subtype type="string">Standard</subtype>
					<type type="string">Adventuring Gear</type>
					<weight type="number">1</weight>
				</id-00004>
				<id-00005>
					<carried type="number">1</carried>
					<cost type="string">2 sp</cost>
					<count type="number">1</count>
					<isidentified type="number">1</isidentified>
					<locked type="number">1</locked>
					<name type="string">Waterskin</name>
					<subtype type="string">Standard</subtype>
					<type type="string">Adventuring Gear</type>
					<weight type="number">5</weight>
				</id-00005>
				<id-00006>
					<carried type="number">1</carried>
					<cost type="string">2 sp</cost>
					<count type="number">1</count>
					<description type="formattedtext">
						<p>This tin box contains a cup and simple cutlery. The box clamps together, and one side can be used as a cooking pan and the other as a plate or shallow bowl.</p>
					</description>
					<isidentified type="number">1</isidentified>
					<locked type="number">1</locked>
					<name type="string">Mess Kit</name>
					<subtype type="string">Equipment Kits</subtype>
					<type type="string">Adventuring Gear</type>
					<weight type="number">1</weight>
				</id-00006>
				<id-00007>
					<carried type="number">1</carried>
					<cost type="string">1 gp</cost>
					<count type="number">1</count>
					<isidentified type="number">1</isidentified>
					<locked type="number">1</locked>
					<name type="string">Rope, Hempen (50 Feet)</name>
					<subtype type="string">Standard</subtype>
					<type type="string">Adventuring Gear</type>
					<weight type="number">10</weight>
				</id-00007>
				<id-00008>
					<carried type="number">1</carried>
					<cost type="string">2 gp</cost>
					<count type="number">1</count>
					<isidentified type="number">1</isidentified>
					<locked type="number">1</locked>
					<name type="string">Backpack (Empty)</name>
					<subtype type="string">Standard</subtype>
					<type type="string">Adventuring Gear</type>
					<weight type="number">5</weight>
				</id-00008>
				<id-00009>
					<carried type="number">2</carried>
					<cost type="string">1 sp</cost>
					<count type="number">1</count>
					<damage type="string">1d4 bludgeoning</damage>
					<isidentified type="number">1</isidentified>
					<locked type="number">1</locked>
					<name type="string">Club</name>
					<properties type="string">Light</properties>
					<subtype type="string">Simple Melee Weapons</subtype>
					<type type="string">Weapon</type>
					<weight type="number">2</weight>
				</id-00009>
				<id-00010>
					<ac type="number">13</ac>
					<carried type="number">2</carried>
					<cost type="string">50 gp</cost>
					<count type="number">1</count>
					<description type="formattedtext">
						<p>Medium armor offers more protection than light armor, but it also impairs movement more. If you wear medium armor, you add your Dexterity modifier, to a maximum of +2, to the base number from your armor type to determine your Armor Class.</p>
						<p>Made of interlocking metal rings, a chain shirt is worn between layers of clothing or leather. This armor offers modest protection to the wearer's upper body and allows the sound of the rings rubbing against one another to be muffled by outer layers.</p>
					</description>
					<dexbonus type="string">Yes (max 2)</dexbonus>
					<isidentified type="number">1</isidentified>
					<locked type="number">1</locked>
					<name type="string">Chain Shirt</name>
					<stealth type="string">-</stealth>
					<strength type="string">-</strength>
					<subtype type="string">Medium Armor</subtype>
					<type type="string">Armor</type>
					<weight type="number">20</weight>
				</id-00010>
			</inventorylist>
			<journalist>
			</journalist>
			<journallist>
				<id-00001>
					<date type="string">1/2/1492</date>
					<journaltext type="formattedtext">
						<p>Todays Shoping Trip</p>
						<p></p>
						<p>We killed a bunch of baddies</p>
					</journaltext>
					<name type="string">Test Entry</name>
					<purchases type="formattedtext">
						<p></p>
					</purchases>
				</id-00001>
			</journallist>
			<languagelist>
				<id-00001>
					<name type="string">One of your choice</name>
				</id-00001>
				<id-00002>
					<name type="string">Common</name>
				</id-00002>
				<id-00003>
					<name type="string">Elvish</name>
				</id-00003>
			</languagelist>
			<level type="number">1</level>
			<name type="string">Bob</name>
			<notes type="string">This is the notes area.</notes>
			<perception type="number">14</perception>
			<perceptionmodifier type="number">0</perceptionmodifier>
			<personalitytraits type="string">My eloquent flattery makes everyone I talk to feel like the most wonderful and important person in the world.</personalitytraits>
			<powergroup>
				<id-00001>
					<castertype type="string">memorization</castertype>
					<name type="string">Spells</name>
					<prepared type="number">4</prepared>
					<stat type="string">intelligence</stat>
				</id-00001>
			</powergroup>
			<powermeta>
				<pactmagicslots1>
					<max type="number">0</max>
					<used type="number">0</used>
				</pactmagicslots1>
				<pactmagicslots2>
					<max type="number">0</max>
					<used type="number">0</used>
				</pactmagicslots2>
				<pactmagicslots3>
					<max type="number">0</max>
					<used type="number">0</used>
				</pactmagicslots3>
				<pactmagicslots4>
					<max type="number">0</max>
					<used type="number">0</used>
				</pactmagicslots4>
				<pactmagicslots5>
					<max type="number">0</max>
					<used type="number">0</used>
				</pactmagicslots5>
				<pactmagicslots6>
					<max type="number">0</max>
					<used type="number">0</used>
				</pactmagicslots6>
				<pactmagicslots7>
					<max type="number">0</max>
					<used type="number">0</used>
				</pactmagicslots7>
				<pactmagicslots8>
					<max type="number">0</max>
					<used type="number">0</used>
				</pactmagicslots8>
				<pactmagicslots9>
					<max type="number">0</max>
					<used type="number">0</used>
				</pactmagicslots9>
				<spellslots1>
					<max type="number">2</max>
				</spellslots1>
				<spellslots2>
					<max type="number">0</max>
				</spellslots2>
				<spellslots3>
					<max type="number">0</max>
				</spellslots3>
				<spellslots4>
					<max type="number">0</max>
				</spellslots4>
				<spellslots5>
					<max type="number">0</max>
				</spellslots5>
				<spellslots6>
					<max type="number">0</max>
				</spellslots6>
				<spellslots7>
					<max type="number">0</max>
				</spellslots7>
				<spellslots8>
					<max type="number">0</max>
				</spellslots8>
				<spellslots9>
					<max type="number">0</max>
				</spellslots9>
			</powermeta>
			<powermode type="string">standard</powermode>
			<powers>
				<id-00001>
					<actions>
					</actions>
					<cast type="number">0</cast>
					<castingtime type="string">1 action</castingtime>
					<components type="string">V, S, M (a short piece of copper wire)</components>
					<description type="formattedtext">
						<p>You point your finger toward a creature within range and whisper a message. The target (and only the target) hears the message and can reply in a whisper that only you can hear.</p>
						<p>You can cast this spell through solid objects if you are familiar with the target and know it is beyond the barrier. Magical silence. 1 foot of stone, 1 inch of common metal, a thin sheet of lead, or 3 feet of wood blocks the spell. The spell doesn't have to follow a straight line and can travel freely around corners or through openings.</p>
					</description>
					<duration type="string">1 round</duration>
					<group type="string">Spells</group>
					<level type="number">0</level>
					<locked type="number">1</locked>
					<name type="string">Message</name>
					<prepared type="number">0</prepared>
					<range type="string">120 feet</range>
					<school type="string">Transmutation</school>
					<source type="string">Bard, Eldritch Knight, Sorcerer, Wizard, Arcane Trickster</source>
				</id-00001>
				<id-00002>
					<actions>
						<id-00001>
							<order type="number">1</order>
							<savemagic type="number">1</savemagic>
							<savetype type="string">constitution</savetype>
							<type type="string">cast</type>
						</id-00001>
						<id-00002>
							<damagelist>
								<id-00001>
									<bonus type="number">0</bonus>
									<dice type="dice">d12</dice>
									<type type="string">poison</type>
								</id-00001>
							</damagelist>
							<order type="number">2</order>
							<type type="string">damage</type>
						</id-00002>
					</actions>
					<cast type="number">0</cast>
					<castingtime type="string">1 action</castingtime>
					<components type="string">V, S</components>
					<description type="formattedtext">
						<p>You extend your hand toward a creature you can see within range and project a puff of noxious gas from your palm. The creature must succeed on a Constitution saving throw or take 1d12 poison damage.</p>
						<p>This spell's damage increases by 1d12 when you reach 5th level (2d12), 11th level (3d12), and 17th level (4d12).</p>
					</description>
					<duration type="string">Instantaneous</duration>
					<group type="string">Spells</group>
					<level type="number">0</level>
					<locked type="number">1</locked>
					<name type="string">Poison Spray</name>
					<prepared type="number">0</prepared>
					<range type="string">10 feet</range>
					<ritual type="number">0</ritual>
					<school type="string">Conjuration</school>
					<source type="string">Druid, Eldritch Knight, Sorcerer, Warlock, Wizard, Arcane Trickster</source>
				</id-00002>
				<id-00003>
					<actions>
						<id-00001>
							<order type="number">1</order>
							<savemagic type="number">1</savemagic>
							<savetype type="string">wisdom</savetype>
							<type type="string">cast</type>
						</id-00001>
						<id-00002>
							<damagelist>
								<id-00001>
									<bonus type="number">0</bonus>
									<dice type="dice">d8</dice>
									<type type="string">necrotic</type>
								</id-00001>
							</damagelist>
							<order type="number">2</order>
							<type type="string">damage</type>
						</id-00002>
						<id-00003>
							<damagelist>
								<id-00001>
									<bonus type="number">0</bonus>
									<dice type="dice">d12</dice>
									<type type="string">necrotic</type>
								</id-00001>
							</damagelist>
							<order type="number">3</order>
							<type type="string">damage</type>
						</id-00003>
					</actions>
					<cast type="number">0</cast>
					<castingtime type="string">1 action</castingtime>
					<components type="string">V, S</components>
					<description type="formattedtext">
						<p>You point at one creature you can see within range, and the sound of a dolorous bell fills the air around it for a moment. The target must succeed on a Wisdom saving throw or take 1d8 necrotic damage. If the target is missing any of its hit points, it instead takes 1d12 necrotic damage.</p>
						<p>The spell's damage increases by one die when you reach 5th level (2d8 or 2d12), 11th level (3d8 or 3d12), and 17th level (4d8 or 4d12).</p>
					</description>
					<duration type="string">Instantaneous</duration>
					<group type="string">Spells</group>
					<level type="number">0</level>
					<locked type="number">1</locked>
					<name type="string">Toll the Dead</name>
					<prepared type="number">0</prepared>
					<range type="string">60 feet</range>
					<ritual type="number">0</ritual>
					<school type="string">Necromancy</school>
					<source type="string">Cleric, Warlock, Wizard</source>
				</id-00003>
				<id-00004>
					<actions>
					</actions>
					<cast type="number">0</cast>
					<castingtime type="string">1 action</castingtime>
					<components type="string">V, S, M (a pinch of soot and salt)</components>
					<description type="formattedtext">
						<p>For the duration, you understand the literal meaning of any spoken language that you hear. You also understand any written language that you see, but you must be touching the surface on which the words are written. It takes about 1 minute to read one page of text.</p>
						<p>This spell doesn't decode secret messages in a text or a glyph, such as an arcane sigil, that isn't part of a written language.</p>
					</description>
					<duration type="string">1 hour</duration>
					<group type="string">Spells</group>
					<level type="number">1</level>
					<locked type="number">1</locked>
					<name type="string">Comprehend Languages</name>
					<prepared type="number">0</prepared>
					<range type="string">Self</range>
					<ritual type="number">1</ritual>
					<school type="string">Divination</school>
					<source type="string">Bard, Eldritch Knight, Sorcerer, Warlock, Wizard, Arcane Trickster</source>
				</id-00004>
				<id-00005>
					<actions>
						<id-00001>
							<durmod type="number">1</durmod>
							<label type="string">Blinded</label>
							<order type="number">1</order>
							<type type="string">effect</type>
						</id-00001>
					</actions>
					<cast type="number">0</cast>
					<castingtime type="string">1 action</castingtime>
					<components type="string">V, S, M (a pinch of powder or sand that is colored red, yellow, and blue)</components>
					<description type="formattedtext">
						<p>Upon casting this spell, the wizard causes a vivid, fan-shaped spray of clashing colors to spring forth from his hand. From one to six creatures (1d6) within the area are affected in order of increasing distance from the wizard. All creatures above the level of the spellcaster and all those of 6th level or 6 Hit Dice or more are entitled to a saving throw vs. spell. Blind or unseeing creatures are not affected by the spell.</p>
						<p>Creatures not allowed or failing saving throws, and whose Hit Dice or levels are less than or equal to the spellcaster's level, are struck unconscious for 2d4 rounds; those with Hit Dice or levels 1 or 2 greater than the wizard's level are blinded for 1d4 rounds; those with Hit Dice or levels 3 or more greater than that of the spellcaster are stunned (reeling and unable to think or act coherently) for one round.</p>
					</description>
					<duration type="string">1 round</duration>
					<group type="string">Spells</group>
					<level type="number">1</level>
					<locked type="number">1</locked>
					<name type="string">Color Spray</name>
					<prepared type="number">0</prepared>
					<range type="string">Se lf (15-foot cone)</range>
					<ritual type="number">0</ritual>
					<school type="string">Illusion</school>
					<source type="string">Eldritch Knight, Sorcerer, Wizard, Arcane Trickster</source>
				</id-00005>
				<id-00006>
					<actions>
						<id-00001>
							<atktype type="string">ranged</atktype>
							<order type="number">1</order>
							<savemagic type="number">1</savemagic>
							<savetype type="string">dexterity</savetype>
							<type type="string">cast</type>
						</id-00001>
						<id-00002>
							<damagelist>
								<id-00001>
									<bonus type="number">0</bonus>
									<dice type="dice">d10</dice>
									<type type="string">piercing,magic</type>
								</id-00001>
							</damagelist>
							<order type="number">2</order>
							<type type="string">damage</type>
						</id-00002>
						<id-00003>
							<damagelist>
								<id-00001>
									<bonus type="number">0</bonus>
									<dice type="dice">d6</dice>
									<type type="string">cold,magic</type>
								</id-00001>
							</damagelist>
							<order type="number">3</order>
							<type type="string">damage</type>
						</id-00003>
					</actions>
					<cast type="number">0</cast>
					<castingtime type="string">1 action</castingtime>
					<components type="string">S, M (a drop of water or a piece of ice)</components>
					<description type="formattedtext">
						<p>You create a shard of ice and fling it at one creature within range. Make a ranged spell attack against the target. On a hit, the target takes 1d10 piercing damage. Hit or miss, the shard then explodes. The target and each creature within 5 feet of it must succeed on a Dexterity saving throw or take 1d6 cold damage + 1d6 additional cold damage every 2 levels to a max of 6d6 additional damage.</p>
						<p><b><i>At Higher Levels. </i></b>When you cast this spell using a spell slot of 2nd level or higher, the cold damage increases by 1d6 for each slot level above 1st.</p>
					</description>
					<duration type="string">Instantaneous</duration>
					<group type="string">Spells</group>
					<level type="number">1</level>
					<locked type="number">1</locked>
					<name type="string">Ice Knife</name>
					<prepared type="number">0</prepared>
					<range type="string">60 feet</range>
					<ritual type="number">0</ritual>
					<school type="string">Conjuration</school>
					<source type="string">Druid, Sorcerer, Wizard</source>
				</id-00006>
				<id-00007>
					<actions>
					</actions>
					<cast type="number">0</cast>
					<castingtime type="string">1 action</castingtime>
					<components type="string">V, S, M (either a pinch of dried carrot or an agate)</components>
					<description type="formattedtext">
						<p>You touch a willing creature to grant it the ability to see in the dark. For the duration, that creature has darkvision out to a range of 60 feet.</p>
					</description>
					<duration type="string">8 hours</duration>
					<group type="string">Spells</group>
					<level type="number">2</level>
					<locked type="number">1</locked>
					<name type="string">Darkvision</name>
					<prepared type="number">0</prepared>
					<range type="string">Touch</range>
					<school type="string">Transmutation</school>
					<source type="string">Druid, Eldritch Knight, Monk, Ranger, Sorcerer, Wizard, Arcane Trickster</source>
				</id-00007>
				<id-00008>
					<actions>
						<id-00001>
							<onmissdamage type="string">half</onmissdamage>
							<order type="number">1</order>
							<savemagic type="number">1</savemagic>
							<savetype type="string">dexterity</savetype>
							<type type="string">cast</type>
						</id-00001>
						<id-00002>
							<damagelist>
								<id-00001>
									<bonus type="number">0</bonus>
									<dice type="dice">d6,d6,d6,d6,d6,d6,d6,d6,d6,d6</dice>
									<statmult type="number">1</statmult>
								</id-00001>
							</damagelist>
							<order type="number">2</order>
							<type type="string">damage</type>
						</id-00002>
					</actions>
					<cast type="number">0</cast>
					<castingtime type="string">1 bonus action</castingtime>
					<components type="string">V, S, M (a hot pepper)</components>
					<description type="formattedtext">
						<p>You touch one willing creature and imbue it with the power to spew magical energy from its mouth, provided it has one. Choose acid, cold, fire, lightning, or poison. Until the spell ends, the creature can use an action to exhale energy of the chosen type in a 15-foot cone. Each creature in that area must make a Dexterity saving throw, taking 1d6/caster level to a max of 10d6 damage of the chosen type on a failed save, or half as much damage on a successful one.</p>
						<p><b><i>At Higher Levels. </i></b>When you cast this spell using a spell slot of 3rd level or higher, the damage increases by 1d6 for each slot level above 2nd.</p>
					</description>
					<duration type="string">Concentration, up to 1 minute</duration>
					<group type="string">Spells</group>
					<level type="number">2</level>
					<locked type="number">1</locked>
					<name type="string">Dragon's Breath</name>
					<prepared type="number">0</prepared>
					<range type="string">Touch</range>
					<school type="string">Transmutation</school>
					<source type="string">Sorcerer, Wizard</source>
				</id-00008>
			</powers>
			<profbonus type="number">2</profbonus>
			<proficiencylist>
				<id-00001>
					<name type="string">Weapon: Daggers, darts, slings, quarterstaffs, light crossbows</name>
				</id-00001>
				<id-00002>
					<name type="string">Tool: One type of gaming set</name>
				</id-00002>
			</proficiencylist>
			<race type="string">Dark Elf (Drow)</race>
			<racelink type="windowreference">
				<class>reference_race</class>
				<recordname>reference.racedata.elf@BMDC Player Guide</recordname>
			</racelink>
			<senses type="string">Superior Darkvision 120</senses>
			<size type="string">Medium</size>
			<skilllist>
				<id-00001>
					<misc type="number">0</misc>
					<name type="string">Perception</name>
					<prof type="number">1</prof>
					<stat type="string">wisdom</stat>
					<total type="number">4</total>
				</id-00001>
				<id-00002>
					<misc type="number">0</misc>
					<name type="string">Arcana</name>
					<prof type="number">1</prof>
					<stat type="string">intelligence</stat>
					<total type="number">5</total>
				</id-00002>
				<id-00003>
					<misc type="number">0</misc>
					<name type="string">Persuasion</name>
					<prof type="number">1</prof>
					<stat type="string">charisma</stat>
					<total type="number">2</total>
				</id-00003>
				<id-00004>
					<misc type="number">0</misc>
					<name type="string">Nature</name>
					<prof type="number">0</prof>
					<stat type="string">intelligence</stat>
					<total type="number">3</total>
				</id-00004>
				<id-00005>
					<misc type="number">0</misc>
					<name type="string">Medicine</name>
					<prof type="number">0</prof>
					<stat type="string">wisdom</stat>
					<total type="number">2</total>
				</id-00005>
				<id-00006>
					<misc type="number">0</misc>
					<name type="string">Survival</name>
					<prof type="number">0</prof>
					<stat type="string">wisdom</stat>
					<total type="number">2</total>
				</id-00006>
				<id-00007>
					<misc type="number">0</misc>
					<name type="string">Performance</name>
					<prof type="number">0</prof>
					<stat type="string">charisma</stat>
					<total type="number">0</total>
				</id-00007>
				<id-00008>
					<misc type="number">0</misc>
					<name type="string">Acrobatics</name>
					<prof type="number">0</prof>
					<stat type="string">dexterity</stat>
					<total type="number">4</total>
				</id-00008>
				<id-00009>
					<misc type="number">0</misc>
					<name type="string">Religion</name>
					<prof type="number">0</prof>
					<stat type="string">intelligence</stat>
					<total type="number">3</total>
				</id-00009>
				<id-00010>
					<misc type="number">0</misc>
					<name type="string">Athletics</name>
					<prof type="number">0</prof>
					<stat type="string">strength</stat>
					<total type="number">2</total>
				</id-00010>
				<id-00011>
					<misc type="number">0</misc>
					<name type="string">Sleight of Hand</name>
					<prof type="number">0</prof>
					<stat type="string">dexterity</stat>
					<total type="number">4</total>
				</id-00011>
				<id-00012>
					<misc type="number">0</misc>
					<name type="string">Insight</name>
					<prof type="number">0</prof>
					<stat type="string">wisdom</stat>
					<total type="number">2</total>
				</id-00012>
				<id-00013>
					<misc type="number">0</misc>
					<name type="string">Intimidation</name>
					<prof type="number">0</prof>
					<stat type="string">charisma</stat>
					<total type="number">0</total>
				</id-00013>
				<id-00014>
					<misc type="number">0</misc>
					<name type="string">Deception</name>
					<prof type="number">0</prof>
					<stat type="string">charisma</stat>
					<total type="number">0</total>
				</id-00014>
				<id-00015>
					<misc type="number">0</misc>
					<name type="string">Investigation</name>
					<prof type="number">1</prof>
					<stat type="string">intelligence</stat>
					<total type="number">5</total>
				</id-00015>
				<id-00016>
					<misc type="number">0</misc>
					<name type="string">Stealth</name>
					<prof type="number">0</prof>
					<stat type="string">dexterity</stat>
					<total type="number">4</total>
				</id-00016>
				<id-00017>
					<misc type="number">0</misc>
					<name type="string">History</name>
					<prof type="number">1</prof>
					<stat type="string">intelligence</stat>
					<total type="number">5</total>
				</id-00017>
				<id-00018>
					<misc type="number">0</misc>
					<name type="string">Animal Handling</name>
					<prof type="number">0</prof>
					<stat type="string">wisdom</stat>
					<total type="number">2</total>
				</id-00018>
			</skilllist>
			<speed>
				<armor type="number">0</armor>
				<base type="number">30</base>
				<misc type="number">0</misc>
				<temporary type="number">0</temporary>
				<total type="number">30</total>
			</speed>
			<temp>
			</temp>
			<temphpEdit type="number">0</temphpEdit>
			<token type="token">portrait_id-00002_token</token>
			<traitlist>
				<id-00001>
					<locked type="number">1</locked>
					<name type="string">Trance</name>
					<source type="string">Elf</source>
					<text type="formattedtext">
						<p>Elves don't need to sleep. Instead, they meditate deeply, remaining semiconscious, for 4 hours a day. (The Common word for such meditation is &#34;trance.&#34;) While meditating, you can dream after a fashion; such dreams are actually mental exercises that have become reflexive through years of practice. After resting in this way, you gain the same benefit that a human does from 8 hours of sleep.</p>
					</text>
					<type type="string">racial</type>
				</id-00001>
				<id-00002>
					<locked type="number">1</locked>
					<name type="string">Keen Senses</name>
					<source type="string">Elf</source>
					<text type="formattedtext">
						<p>You have proficiency in the Perception skill.</p>
					</text>
					<type type="string">racial</type>
				</id-00002>
				<id-00003>
					<locked type="number">1</locked>
					<name type="string">Fey Ancestry</name>
					<source type="string">Elf</source>
					<text type="formattedtext">
						<p>You have advantage on saving throws against being charmed, and magic can't put you to sleep.</p>
					</text>
					<type type="string">racial</type>
				</id-00003>
				<id-00004>
					<locked type="number">1</locked>
					<name type="string">Sunlight Sensitivity</name>
					<source type="string">Dark Elf (Drow)</source>
					<text type="formattedtext">
						<p>You have disadvantage on attack rolls and on Wisdom (Perception) checks that rely on sight when you, the target of your attack, or whatever you are trying to perceive is in direct sunlight.</p>
					</text>
					<type type="string">subracial</type>
				</id-00004>
				<id-00005>
					<locked type="number">1</locked>
					<name type="string">Drow Weapon Training</name>
					<source type="string">Dark Elf (Drow)</source>
					<text type="formattedtext">
						<p>You have proficiency with rapiers, shortswords and hand crossbows.</p>
					</text>
					<type type="string">subracial</type>
				</id-00005>
				<id-00006>
					<locked type="number">1</locked>
					<name type="string">Drow Magic</name>
					<source type="string">Dark Elf (Drow)</source>
					<text type="formattedtext">
						<p>You know the dancing lights cantrip. When you reach 3rd level, you can cast the faerie fire spell once per day (after completion of a long rest). When you reach 5th level, you can also cast the darkness spell once per day. Charisma is your spellcasting ability for these spells.</p>
					</text>
					<type type="string">subracial</type>
				</id-00006>
			</traitlist>
			<weaponlist>
				<id-00001>
					<attackbonus type="number">0</attackbonus>
					<carried type="number">2</carried>
					<damagelist>
						<id-00001>
							<bonus type="number">0</bonus>
							<dice type="dice">d4</dice>
							<stat type="string">base</stat>
							<type type="string">bludgeoning</type>
						</id-00001>
					</damagelist>
					<isidentified type="number">1</isidentified>
					<maxammo type="number">0</maxammo>
					<name type="string">Club</name>
					<prof type="number">1</prof>
					<properties type="string">Light</properties>
					<shortcut type="windowreference">
						<class>item</class>
						<recordname>....inventorylist.id-00009</recordname>
					</shortcut>
					<type type="number">0</type>
				</id-00001>
			</weaponlist>
			<weight type="string">166lbs</weight>
			<woundsEdit type="number">0</woundsEdit>
		</id-00002>
	</charsheet>
         */

    }
    public class RecordLink
    {
        public string RecordClass { get; set; } = "reference_background";
        public string RecordName { get; set; }
    }

    namespace Darkspyre.DnD.Data.CharSheetData
    {
        
       
        public class CharSheetClass : BaseEntity
        {
            public string CasterLevelInvMult { get; set; }
            public string HDDie { get; set; }
            public int HDUsed { get; set; }
            public int Level { get; set; }
            public string Name { get; set; }
            public RecordLink Shortcut { get; set; }
        }

        public class CoinSlot : BaseEntity
        {        
            public int Amount { get; set; }
            public string Name { get; set; }
        }
    }
       
}
